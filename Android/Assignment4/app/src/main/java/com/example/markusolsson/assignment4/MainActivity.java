package com.example.markusolsson.assignment4;

import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.net.Uri;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.hardware.SensorEventListener;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.os.Build;
import android.widget.Toast;


public class MainActivity extends ActionBarActivity
implements PlaylistFragment.OnFragmentInteractionListener,
PlayerFragment.OnFragmentInteractionListener{
private int backCount = 0;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        if (savedInstanceState == null) {
            ChangeScreen(new PlaylistFragment(), "playlist");
        }
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
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
    public void ChangeScreen(android.app.Fragment frag, String tag)
    {
        backCount = 0;
        getFragmentManager().beginTransaction().replace(R.id.container, frag, tag).commit();
    }

    @Override
    public void onBackPressed()
    {
        PlayerFragment pFrag = (PlayerFragment)getFragmentManager().findFragmentByTag("player");
        PlaylistFragment plFrag = (PlaylistFragment)getFragmentManager().findFragmentByTag("playlist");
        if(pFrag != null)
        {
        if (pFrag.isVisible()) {
            backCount = 0;
            ChangeScreen(new PlaylistFragment(), "playlist");
        }
        }
        if(plFrag != null)
        {
         if (plFrag.isVisible()) {
            if ((3 - backCount) == 1) {
                System.exit(0);
            }
            Toast.makeText(this, "Press " + (2 - backCount) + " more times to exit.", Toast.LENGTH_SHORT).show();
            backCount++;
        }
        }
    }
}
