package com.example.markus.app1;

import android.app.Activity;
import android.app.Fragment;
import android.net.Uri;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;


public class ChatActivity extends Activity
implements Grouplist.OnFragmentInteractionListener,
         ChatFragment.OnFragmentInteractionListener
{
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle("ChattMästarN");
        ChangeScreen(new Grouplist(), R.id.grouplistfragment, R.layout.fragment_grouplist);
    }
    public void onFragmentInteraction(Uri uri){
    }

    @Override
    public void onBackPressed() {
        ChangeScreen(new Grouplist(), R.id.grouplistfragment, R.layout.fragment_grouplist);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_chat, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
    public void ChangeScreen(Fragment frag, int id, int layout)
    {
        this.setContentView(layout);
        getFragmentManager().beginTransaction()
                .replace(id, frag)
                .commit();
    }
}
