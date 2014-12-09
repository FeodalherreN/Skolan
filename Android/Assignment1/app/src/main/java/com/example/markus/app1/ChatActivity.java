package com.example.markus.app1;

import android.app.Activity;
import android.app.Fragment;
import android.app.FragmentTransaction;
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
        setTitle("MacChatt");
        setContentView(R.layout.activity_chat);
        if(savedInstanceState == null) {
            ChangeScreen(new Grouplist());
        }
    }
    public void onFragmentInteraction(Uri uri){
    }

    @Override
    public void onBackPressed() {
        ChangeScreen(new Grouplist());
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
    public void ChangeScreen(Fragment frag)
    {
        getFragmentManager().beginTransaction()
                .replace(R.id.chatcontainer, frag)
                .commit();
    }
    public void StartChat(String groupName, String groupId)
    {
        ChatFragment fragment = ChatFragment.newInstance(groupName, groupId);
        FragmentTransaction transaction = getFragmentManager().beginTransaction();
        transaction.replace(R.id.chatcontainer, fragment);
        transaction.commit();
    }
}
