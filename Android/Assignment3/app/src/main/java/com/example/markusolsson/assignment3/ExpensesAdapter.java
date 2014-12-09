package com.example.markusolsson.assignment3;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.util.Date;

/**
 * Created by Markus Olsson on 2014-12-08.
 */
public class ExpensesAdapter {

    public static final String MYDATABASE_NAME = "BudgetDB";
    public static final String MYDATABASE_TABLE = "expenses";
    public static final int MYDATABASE_VERSION = 1;
    public static final String KEY_ID = "_id";

    private static final String SCRIPT_CREATE_DATABASE =
            "CREATE TABLE IF NOT EXISTS incomes(_id integer primary key autoincrement, Date text not null, Amount integer, Title text not null);";


    private Context context;
    private SQLiteOpenHelper sqLiteHelper;
    private SQLiteDatabase sqLiteDatabase;

    public ExpensesAdapter(Context c) {
        context = c;
    }

    public ExpensesAdapter openToRead() throws android.database.SQLException {
        sqLiteHelper = new SQLiteHelper(context, MYDATABASE_NAME, null, MYDATABASE_VERSION);
        sqLiteDatabase = sqLiteHelper.getReadableDatabase();
        return this;
    }

    public ExpensesAdapter openToWrite() throws android.database.SQLException {
        sqLiteHelper = new SQLiteHelper(context, MYDATABASE_NAME, null, MYDATABASE_VERSION);
        sqLiteDatabase = sqLiteHelper.getWritableDatabase();
        return this;
    }

    public void close() {
        sqLiteHelper.close();
    }

    public long insert(String title, int Amount) {

        ContentValues contentValues = new ContentValues();
        contentValues.put("title", title);
        contentValues.put("amount", Amount);
        Date date = new Date();
        contentValues.put("date", date.toLocaleString());
        return sqLiteDatabase.insert("expenses", null, contentValues);
    }

    public int deleteAll() {
        return sqLiteDatabase.delete(MYDATABASE_TABLE, null, null);
    }

    public Cursor queueAll() {
        String[] columns = new String[]{KEY_ID, "title", "amount", "date"};
        Cursor cursor = sqLiteDatabase.query(MYDATABASE_TABLE, columns,
                null, null, null, null, null);

        return cursor;
    }
    public Cursor Calculate()
    {
        Cursor x = sqLiteDatabase.rawQuery("SELECT SUM(amount) FROM expenses;", null);
        return x;
    }
    public class SQLiteHelper extends SQLiteOpenHelper {

        public SQLiteHelper(Context context, String name,
                            SQLiteDatabase.CursorFactory factory, int version) {
            super(context, name, factory, version);
        }

        @Override
        public void onCreate(SQLiteDatabase db) {
            // TODO Auto-generated method stub
        }

        @Override
        public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
            // TODO Auto-generated method stub

        }
    }
}
