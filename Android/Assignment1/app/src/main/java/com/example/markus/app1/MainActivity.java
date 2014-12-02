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
        mFirebase = new Firebase("https://brilliant-heat-3941.firebaseio.com/");
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
        final EditText username = (EditText)findViewById(R.id.txtregusername);
        final EditText password = (EditText)findViewById(R.id.txtregpassword);
        final EditText email = (EditText)findViewById(R.id.txtregemail);
        mFirebase.createUser(email.getText().toString(),password.getText().toString(), new Firebase.ResultHandler() {
            @Override
            public void onSuccess() {
                Toast.makeText(getApplicationContext(),"Registration successful", Toast.LENGTH_SHORT).show();
                ChangeScreen(new Login(), R.id.loginfragment, R.layout.fragment_login);
            }

            @Override
            public void onError(FirebaseError firebaseError) {
                Toast.makeText(getApplicationContext(),"Registration failed, try again.", Toast.LENGTH_SHORT).show();
                username.setText("");
                password.setText("");
                email.setText("");
            }
        });
    }
    public void LoginClicked(View view)
    {
        final EditText username = (EditText)findViewById(R.id.txtusername);
        final EditText password = (EditText)findViewById(R.id.txtpassword);
        mFirebase.authWithPassword(username.getText().toString(),password.getText().toString(), new Firebase.AuthResultHandler() {
                    @Override
                    public void onAuthenticated(AuthData authData) {
                        System.out.println("User ID: " + authData.getUid() + ", Provider: " + authData.getProvider());
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
