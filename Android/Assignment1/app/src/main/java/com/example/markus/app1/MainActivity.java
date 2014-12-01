package com.example.markus.app1;

import android.app.ActionBar;
import android.app.Activity;
import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.text.Layout;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

import java.io.FileDescriptor;
import java.io.PrintWriter;


public class MainActivity extends Activity
        implements RegisterFragment.OnFragmentInteractionListener,
        AboutFragment.OnFragmentInteractionListener,
        Login.OnFragmentInteractionListener
{
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (savedInstanceState == null)
        {
            setTitle("ChattmästarN");
            ChangeScreen(new Login(), R.id.loginfragment, R.layout.fragment_login);
        }
    }
    public void onFragmentInteraction(Uri uri){
    }

    @Override
    public void onBackPressed() {
        ChangeScreen(new Login(), R.id.loginfragment, R.layout.fragment_login);
    }

    public void RegisterBtnClicked(View view)
    {
        ChangeScreen(new RegisterFragment(), R.id.registerfragment, R.layout.fragment_register);
    }
    public void RegRegClicked(View view)
    {
        ChangeScreen(new Login(), R.id.loginfragment, R.layout.fragment_login);
    }
    public void LoginClicked(View view)
    {
        Intent i = new Intent(getApplicationContext(), ChatActivity.class);
        startActivity(i);
    }
    public void AboutPressed(View view)
    {
        ChangeScreen(new AboutFragment(), R.id.aboutfragment, R.layout.fragment_about);
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
