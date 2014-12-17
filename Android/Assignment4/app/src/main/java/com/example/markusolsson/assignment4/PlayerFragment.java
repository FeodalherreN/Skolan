package com.example.markusolsson.assignment4;

import android.app.Activity;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Timer;
import java.util.TimerTask;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link PlayerFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link PlayerFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class PlayerFragment extends Fragment implements SensorEventListener {
    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";
    private static final String ARG_PARAM3 = "param3";

    // TODO: Rename and change types of parameters
    private Activity mActivity;
    private String Url;
    private String Name;
    private Boolean hasSingleKnocked = false;
    private Boolean hasDoubleKnocked = false;
    private Boolean hasTripleKnocked = false;
    private String Position;
    private Timer klockTimer;
    private SongLibrary mSongLibrary;
    private MediaPlayer mMediaPlayer = new MediaPlayer();
    private OnFragmentInteractionListener mListener;
    private Sensor mSensor;
    private SensorManager mSensorManager;

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment PlayerFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static PlayerFragment newInstance(String param1, String param2, String Position) {
        PlayerFragment fragment = new PlayerFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        args.putString(ARG_PARAM3, Position);
        fragment.setArguments(args);
        return fragment;
    }

    public PlayerFragment() {
        // Required empty public constructor
    }
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            Url = getArguments().getString(ARG_PARAM1);
            Name = getArguments().getString(ARG_PARAM2);
            Position = getArguments().getString(ARG_PARAM3);
            mSensorManager = (SensorManager)getActivity().getSystemService(getActivity().SENSOR_SERVICE);
            mSensor = mSensorManager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER);
            klockTimer = new Timer();
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View root = inflater.inflate(R.layout.fragment_player, container, false);
        final ImageButton btnPlayPause = (ImageButton)root.findViewById(R.id.btnPause);
        ImageButton btnStop = (ImageButton)root.findViewById(R.id.btnStop);
        ImageButton btnPrevious = (ImageButton)root.findViewById(R.id.btnRewind);
        ImageButton btnNext = (ImageButton)root.findViewById(R.id.btnForward);
        TextView SongTitle = (TextView)root.findViewById(R.id.currentSong);
        SongTitle.setText(Name);
        btnPlayPause.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (btnPlayPause.getTag().equals("pause")) {
                    btnPlayPause.setImageResource(R.drawable.play);
                    PauseSong();
                    btnPlayPause.setTag("play");
                } else if (btnPlayPause.getTag().equals("play")) {
                    btnPlayPause.setImageResource(R.drawable.pause);
                    PlaySong();
                    btnPlayPause.setTag("pause");
                }
            }
        });
        btnStop.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                StopSong(btnPlayPause);
            }
        });
        btnNext.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Next();
            }
        });
        btnPrevious.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Previous();
            }
        });
        mMediaPlayer.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
            @Override
            public void onCompletion(MediaPlayer mp) {
                btnPlayPause.setImageResource(R.drawable.play);
                btnPlayPause.setTag("play");
            }
        });
        return root;
    }
    private void Next()
    {
        ArrayList<HashMap<String,String>> mPlayList;
        mSongLibrary = new SongLibrary();
        mPlayList = mSongLibrary.getPlayList(getActivity());
        int newPos = Integer.parseInt(Position) + 1;
        if(newPos <= mPlayList.size() -1)
        {
            if (mMediaPlayer!=null)
                mMediaPlayer.stop();
            HashMap<String, String> temp = mPlayList.get(newPos);
            String newUrl = temp.get("songPath");
            String newSongName = temp.get("songTitle");
            getActivity().getFragmentManager().beginTransaction().replace(R.id.container, new PlayerFragment().newInstance(newUrl, newSongName, String.valueOf(newPos)), "player").commit();
        }
    }
    private void Previous()
    {
        ArrayList<HashMap<String,String>> mPlayList;
        mSongLibrary = new SongLibrary();
        mPlayList = mSongLibrary.getPlayList(getActivity());
        int newPos = Integer.parseInt(Position) - 1;
        if(newPos >= 0)
        {
            if (mMediaPlayer!=null)
                mMediaPlayer.stop();
            HashMap<String, String> temp = mPlayList.get(newPos);
            String newUrl = temp.get("songPath");
            String newSongName = temp.get("songTitle");
            getActivity().getFragmentManager().beginTransaction().replace(R.id.container, new PlayerFragment().newInstance(newUrl, newSongName, String.valueOf(newPos)), "player").commit();
        }
    }
    private void StopSong(ImageButton btn)
    {
        if (mMediaPlayer!=null)
        mMediaPlayer.stop();
        btn.setImageResource(R.drawable.play);
        btn.setTag("play");
    }
    private void PauseSong()
    {
        if (mMediaPlayer!=null) {
            if (mMediaPlayer.isPlaying())
                mMediaPlayer.pause();
        }
    }
    private void PlaySong()
    {
        try {
            mMediaPlayer.reset();
            mMediaPlayer.setDataSource(Url);
            mMediaPlayer.prepare();
            mMediaPlayer.start();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    // TODO: Rename method, update argument and hook method into UI event
    public void onButtonPressed(Uri uri) {
        if (mListener != null) {
            mListener.onFragmentInteraction(uri);
        }
    }

    @Override
    public void onAttach(Activity activity) {
        super.onAttach(activity);
        mActivity = activity;
        try {
            mListener = (OnFragmentInteractionListener) activity;
        } catch (ClassCastException e) {
            throw new ClassCastException(activity.toString()
                    + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }
    @Override
    public void onSensorChanged(SensorEvent event) {
        if(event.values[2] > 0.1){
            if(!hasSingleKnocked){
                hasSingleKnocked = true;
                klockTimer.schedule(new TimerTask() {
                    @Override
                    public void run() {
                        if (hasSingleKnocked && !hasDoubleKnocked && !hasTripleKnocked) {
                                PlaySong();
                        } else if (hasSingleKnocked && hasDoubleKnocked && !hasTripleKnocked) {
                            Next();
                        } else if (hasSingleKnocked && hasDoubleKnocked && hasTripleKnocked) {
                            Previous();
                        }
                        hasSingleKnocked = false;
                        hasDoubleKnocked = false;
                        hasTripleKnocked = false;
                    }
                }, 1000);
            }
            else if(hasSingleKnocked && !hasDoubleKnocked){
                hasDoubleKnocked = true;
            }
            else if(hasSingleKnocked && hasDoubleKnocked)
                hasTripleKnocked = true;


        }
    }

    @Override
    public void onAccuracyChanged(Sensor sensor, int accuracy)
    {
    }

    @Override
    public void onResume() {
        super.onResume();
        this.registerSensorListener();
    }

    @Override
    public void onPause() {
        super.onPause();
        this.unregisterSensorListener();
    }

    private void registerSensorListener() {
        mSensorManager.registerListener(this, mSensorManager.getSensorList(Sensor.TYPE_ACCELEROMETER).get(0), SensorManager.SENSOR_DELAY_NORMAL);
    }

    private void unregisterSensorListener() {
        mSensorManager.unregisterListener(this);
    }
    /**
     * This interface must be implemented by activities that contain this
     * fragment to allow an interaction in this fragment to be communicated
     * to the activity and potentially other fragments contained in that
     * activity.
     * <p/>
     * See the Android Training lesson <a href=
     * "http://developer.android.com/training/basics/fragments/communicating.html"
     * >Communicating with Other Fragments</a> for more information.
     */
    public interface OnFragmentInteractionListener {
        // TODO: Update argument type and name
        public void onFragmentInteraction(Uri uri);
    }

}
