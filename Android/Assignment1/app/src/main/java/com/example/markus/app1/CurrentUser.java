package com.example.markus.app1;

/**
 * Created by Markus Olsson on 2014-12-04.
 */
public class CurrentUser {
    public static String currentUser;

    public CurrentUser(){}
    public static void setCurrentUser(String currentUser) {
        CurrentUser.currentUser = currentUser;
    }

    public static String getCurrentUser() {
        return currentUser;
    }
    public static String getCurrentUserMini(){
        return currentUser.substring(0, currentUser.indexOf("@"));
    }
}

