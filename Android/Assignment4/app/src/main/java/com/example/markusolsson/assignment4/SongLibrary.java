package com.example.markusolsson.assignment4;

import android.content.Context;
import android.database.Cursor;
import android.provider.MediaStore;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by Markus Olsson on 2014-12-16.
 */
public class SongLibrary {

    private ArrayList<HashMap<String, String>> songsList;

    public SongLibrary()
    {
        songsList = new ArrayList<HashMap<String, String>>();
    }

    public ArrayList<HashMap<String, String>> getPlayList(Context c) {
        final Cursor mCursor = c.getContentResolver().query(
                MediaStore.Audio.Media.EXTERNAL_CONTENT_URI,
                new String[] { MediaStore.Audio.Media.DISPLAY_NAME, MediaStore.Audio.Media.DATA,MediaStore.Audio.Media.MIME_TYPE }, null, null,
                "LOWER(" + MediaStore.Audio.Media.TITLE + ") ASC");

        String songs_name = "";
        String mAudioPath = "";

    /* run through all the columns we got back and save the data we need into the arraylist for our listview*/
        if (mCursor.moveToFirst()) {
            do {

                String file_type = mCursor.getString(mCursor.getColumnIndexOrThrow(MediaStore.Audio.Media.MIME_TYPE));


                songs_name = mCursor.getString(mCursor.getColumnIndexOrThrow(MediaStore.Audio.Media.DISPLAY_NAME));
                mAudioPath = mCursor.getString(mCursor.getColumnIndexOrThrow(MediaStore.Audio.Media.DATA));
                HashMap<String, String> song = new HashMap<String, String>();

                song.put("songTitle", songs_name);
                song.put("songPath", mAudioPath);

                songsList.add(song);

            } while (mCursor.moveToNext());
        }

        mCursor.close(); //cursor has been consumed so close it
        return songsList;
    }
}
