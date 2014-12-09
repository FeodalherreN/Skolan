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
import android.widget.EditText;
import android.widget.Toast;

import com.firebase.client.AuthData;
import com.firebase.client.Firebase;
import com.firebase.client.FirebaseError;

import java.io.FileDescriptor;
import java.io.PrintWriter;

import static com.example.markus.app1.R.layout.activity_main;


public class MainActivity extends Activity
        implements RegisterFragment.OnFragmentInteractionListener,
        AboutFragment.OnFragmentInteractionListener,
        Login.OnFragmentInteractionListener
{
    Firebase mFirebase;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Firebase.setAndroidContext(this);
        setContentView(R.layout.activity_main);
        mFirebase = new Firebase("https://brilliant-heat-3941.firebaseio.com/");
        if (savedInstanceState == null)
        {
            setTitle("MacChatt");
            ChangeScreen(new Login());
        }
    }

    public void onFragmentInteraction(Uri uri){
    }

    @Override
    public void onBackPressed() {
        ChangeScreen(new Login());
    }

    public void RegisterBtnClicked(View view)
    {
        ChangeScreen(new RegisterFragment());
    }
    public void LoginClicked(View view)
    {
        final EditText username = (EditText)findViewById(R.id.txtusername);
        final EditText password = (EditText)findViewById(R.id.txtpassword);
        mFirebase.authWithPassword(username.getText().toString(),password.getText().toString(), new Firebase.AuthResultHandler() {
                    @Override
                    public void onAuthenticated(AuthData authData) {
                        System.out.println("User ID: " + authData.getUid() + ", Provider: " + authData.getProvider());
                        CurrentUser.setCurrentUser((String) authData.getProviderData().get("email"));
                        Intent i = new Intent(getApplicationContext(), ChatActivity.class);
                        startActivity(i);
                    }

                    @Override
                    public void onAuthenticationError(FirebaseError firebaseError) {
                        Toast.makeText(getApplicationContext(),"Login failed, try again.", Toast.LENGTH_SHORT).show();
                    }
                });
    }
    public void AboutPressed(View view)
    {
        ChangeScreen(new AboutFragment());
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
    public void ChangeScreen(Fragment frag)
    {
        getFragmentManager().beginTransaction()
                .replace(R.id.container, frag)
                .commit();
    }
}
