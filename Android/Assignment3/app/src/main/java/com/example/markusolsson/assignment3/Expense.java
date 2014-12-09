package com.example.markusolsson.assignment3;

import java.util.Date;

/**
 * Created by Markus Olsson on 2014-12-08.
 */
public class Expense {
    private int _id;
    private String date;
    private int amount;
    private String title;

    public Expense(int piId, Date piDate, int piAmount, String piTitle)
    {
        this._id = piId;
        this.date = piDate.toString();
        this.amount = piAmount;
        this.title = piTitle;
    }
}
