package com.example.markus.app1;

import android.app.Activity;
import android.app.Dialog;
import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.firebase.client.ChildEventListener;
import com.firebase.client.DataSnapshot;
import com.firebase.client.Firebase;
import com.firebase.client.FirebaseError;

import java.security.Timestamp;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link ChatFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link ChatFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ChatFragment extends Fragment {
    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String GROUP_NAME = "groupName";
    private static final String GROUP_ID = "groupId";

    // TODO: Rename and change types of parameters
    private String groupName;
    private String groupId;
    private ArrayList<ChatMessage> messages;
    private Firebase mFirebase;
    private ChatMessageAdapter mAdapter;

    private OnFragmentInteractionListener mListener;

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment ChatFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static ChatFragment newInstance(String param1, String param2) {
        ChatFragment fragment = new ChatFragment();
        Bundle args = new Bundle();
        args.putString(GROUP_NAME, param1);
        args.putString(GROUP_ID, param2);
        fragment.setArguments(args);
        return fragment;
    }

    public ChatFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            groupName = getArguments().getString(GROUP_NAME);
            groupId = getArguments().getString(GROUP_ID);
        }
        messages = new ArrayList<ChatMessage>();
        mFirebase = new Firebase("https://brilliant-heat-3941.firebaseio.com/").child(groupId).child("messages");
        mAdapter = new ChatMessageAdapter(getActivity(), messages);
        getActivity().setTitle(groupName);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View root = inflater.inflate(R.layout.fragment_chat, container, false);
        getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
        Button sendMsgBtn = (Button) root.findViewById(R.id.sendbtn);
        final ListView chatList = (ListView) root.findViewById(R.id.chatList);
        final EditText msgTxtbox = (EditText)root.findViewById(R.id.msgTextbox);
        chatList.setAdapter(mAdapter);
        sendMsgBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String inputMsg = msgTxtbox.getText().toString();
                if (!inputMsg.isEmpty()) {
                    DateFormat dateFormat = android.text.format.DateFormat.getDateFormat(getActivity().getApplicationContext());
                    String currentUser = CurrentUser.getCurrentUserMini();
                    Date date = new Date();
                    ChatMessage msg = new ChatMessage(currentUser,inputMsg,dateFormat.format(date));
                    mFirebase.push().setValue(msg, new Firebase.CompletionListener() {
                        @Override
                        public void onComplete(FirebaseError firebaseError, Firebase firebase) {
                            if (firebaseError != null) {
                                Dialog dialog = new Dialog(getActivity());
                                dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
                                dialog.setContentView(R.layout.dialoglayout);
                                TextView text = (TextView) dialog.findViewById(R.id.dialogText);
                                text.setText("Error:\n" + firebaseError.toString());
                                dialog.show();
                            } else {
                                chatList.setSelection(mAdapter.getCount() - 1);
                                msgTxtbox.setText("");
                                InputMethodManager imm = (InputMethodManager) getActivity().getSystemService(Context.INPUT_METHOD_SERVICE);
                                imm.hideSoftInputFromWindow(msgTxtbox.getWindowToken(), 0);
                            }
                        }
                    });
                }
            }
        });
        mFirebase.addChildEventListener(new ChildEventListener() {
            @Override
            public void onChildAdded(DataSnapshot dataSnapshot, String s) {
                Map<String, Object> newMsg = (Map<String, Object>) dataSnapshot.getValue();
                if (!dataSnapshot.getKey().equals("name")) {
                    String newChatMsgId = dataSnapshot.getKey();
                    String newChatMsgFrom = (String) newMsg.get("from");
                    String newChatMsg = (String) newMsg.get("message");
                    String newChatMsgTimestamp = (String) newMsg.get("timestamp");
                    if (!newChatMsg.isEmpty()) {
                        ChatMessage msg = new ChatMessage(newChatMsgId, newChatMsgFrom, newChatMsg, newChatMsgTimestamp);
                        messages.add(msg);
                    }
                    mAdapter.notifyDataSetChanged();
                    ListView chatList = (ListView) getActivity().findViewById(R.id.chatList);
                    chatList.setSelection(mAdapter.getCount() - 1);
                }

            }

            @Override
            public void onChildChanged(DataSnapshot dataSnapshot, String s) {

            }

            @Override
            public void onChildRemoved(DataSnapshot dataSnapshot) {

            }

            @Override
            public void onChildMoved(DataSnapshot dataSnapshot, String s) {

            }

            @Override
            public void onCancelled(FirebaseError firebaseError) {

            }
        });

        return root;
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
