package com.example.markusolsson.assignment3;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.database.Cursor;
import android.database.DatabaseErrorHandler;
import android.net.Uri;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.database.sqlite.*;
import android.os.Build;
import android.widget.Toast;


public class MainActivity extends ActionBarActivity implements
        MainFragment.OnFragmentInteractionListener,
        IncomeFragment.OnFragmentInteractionListener,
        ExpensesFragment.OnFragmentInteractionListener,
        SummaryFragment.OnFragmentInteractionListener,
        AddFragment.OnFragmentInteractionListener{

    private SQLiteDatabase db;
    private IncomeAdapter myIncomeAdapter;
    private ExpensesAdapter myExpenseAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        if (savedInstanceState == null) {
            CreateOrOpenDatabase();
            setTitle("Budget app");
            ChangeScreen(new IncomeFragment(), "Incomes");
        }
    }
    public void CreateOrOpenDatabase()
    {
        db = this.openOrCreateDatabase("BudgetDB", MODE_PRIVATE, null);
        db.execSQL("CREATE TABLE IF NOT EXISTS incomes(_id integer primary key autoincrement, date text not null, amount integer, title text not null);");
        db.execSQL("CREATE TABLE IF NOT EXISTS expenses(_id integer primary key autoincrement, date text not null, amount integer, title text not null);");
    }
    public void onFragmentInteraction(Uri uri){
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_income) {
            ChangeScreen(new IncomeFragment(), "Incomes");
            return true;
        }
        if(id == R.id.action_expenses)
        {
            ChangeScreen(new ExpensesFragment(), "Expenses");
            return true;
        }
        if(id == R.id.action_summary)
        {
            ChangeScreen(new SummaryFragment(), "Summary");
            return true;
        }
        if(id == R.id.action_add)
        {
            ChangeScreen(new AddFragment(), "Add");
            return true;
        }
        if(id == R.id.action_delete) {
            SummaryFragment sm = (SummaryFragment) getFragmentManager().findFragmentByTag("Summary");
            if (sm != null) {
                if (sm.isVisible()) {
                    Toast.makeText(this, "You cannot delete from summary...", Toast.LENGTH_SHORT).show();
                }
            } else {
                DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        switch (which) {
                            case DialogInterface.BUTTON_POSITIVE:
                                IncomeFragment income = (IncomeFragment) getFragmentManager().findFragmentByTag("Incomes");
                                ExpensesFragment expenses = (ExpensesFragment) getFragmentManager().findFragmentByTag("Expenses");
                                if (income != null) {
                                    if (income.isVisible()) {
                                        myIncomeAdapter = new IncomeAdapter(getApplicationContext());
                                        myIncomeAdapter.openToWrite();
                                        myIncomeAdapter.deleteAll();
                                        myIncomeAdapter.close();
                                        ChangeScreen(new IncomeFragment(), "Incomes");
                                    }
                                }
                                if (expenses != null) {
                                    if (expenses.isVisible()) {
                                        myExpenseAdapter = new ExpensesAdapter(getApplicationContext());
                                        myExpenseAdapter.openToWrite();
                                        myExpenseAdapter.deleteAll();
                                        myExpenseAdapter.close();
                                        ChangeScreen(new ExpensesFragment(), "Expenses");
                                    }
                                }
                                break;
                            case DialogInterface.BUTTON_NEGATIVE:
                                break;
                        }
                    }
                };

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.setMessage("Delete all?").setPositiveButton("Yes", dialogClickListener)
                        .setNegativeButton("No", dialogClickListener).show();
            }
        }
        return super.onOptionsItemSelected(item);
    }

    /**
     * A placeholder fragment containing a simple view.
     */
    public static class PlaceholderFragment extends Fragment {

        public PlaceholderFragment() {
        }

        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState) {
            View rootView = inflater.inflate(R.layout.fragment_main, container, false);
            return rootView;
        }
    }
    public void ChangeScreen(android.app.Fragment frag, String title)
    {
        setTitle(title);
        getFragmentManager().beginTransaction()
                .replace(R.id.container, frag, title)
                .commit();
    }
}
