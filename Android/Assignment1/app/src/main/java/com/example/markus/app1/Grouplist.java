package com.example.markus.app1;

import android.app.Activity;
import android.app.Dialog;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.firebase.client.ChildEventListener;
import com.firebase.client.DataSnapshot;
import com.firebase.client.Firebase;
import com.firebase.client.FirebaseError;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link Grouplist.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link Grouplist#newInstance} factory method to
 * create an instance of this fragment.
 */
public class Grouplist extends Fragment {
    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;
    private Firebase mFirebase;

    private ArrayList<Group> groups;
    private ArrayList<String> ids;
    private GroupAdapter mAdapter;

    private OnFragmentInteractionListener mListener;

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment Grouplist.
     */
    // TODO: Rename and change types and number of parameters
    public static Grouplist newInstance(String param1, String param2) {
        Grouplist fragment = new Grouplist();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    public Grouplist() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }
        getActivity().setTitle("Groups");
        groups = new ArrayList<Group>();
        ids = new ArrayList<String>();
        mAdapter = new GroupAdapter(getActivity(), groups);
        mFirebase = new Firebase("https://brilliant-heat-3941.firebaseio.com/");
        mFirebase.addChildEventListener(new ChildEventListener() {
            @Override
            public void onChildAdded(DataSnapshot dataSnapshot, String s)
            {
                Map<String, Object> newGroup = (Map<String,Object>) dataSnapshot.getValue();
                String newGroupId = dataSnapshot.getKey();
                String newGroupName = (String)newGroup.get("name");
                if(!newGroupName.isEmpty()) {
                    Group grp = new Group();
                    grp.setName(newGroupName);
                    groups.add(grp);
                    ids.add(newGroupId);
                }
                mAdapter.notifyDataSetChanged();
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
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View root = inflater.inflate(R.layout.fragment_grouplist, container, false);
        Button AddGroupBtn = (Button)root.findViewById(R.id.GroupAddBtn);
        ListView GroupList = (ListView)root.findViewById(R.id.grouplistview);
        final TextView addGroupText = (TextView)root.findViewById(R.id.GroupTxtAddGroup);
        GroupList.setAdapter(mAdapter);
        GroupList.setClickable(true);
        GroupList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String name = groups.get(position).getName();
                String groupId = ids.get(position);
                ((ChatActivity)getActivity()).StartChat(name, groupId);
            }
        });
        AddGroupBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String groupname = addGroupText.getText().toString();
                if(!groupname.equals(""))
                {
                    Group grp = new Group();
                    grp.setName(groupname);
                    mFirebase.push().setValue(grp, new Firebase.CompletionListener() {
                        @Override
                        public void onComplete(FirebaseError firebaseError, Firebase firebase) {
                        if(firebaseError != null)
                        {
                            Dialog dialog = new Dialog(getActivity());
                            dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
                            dialog.setContentView(R.layout.dialoglayout);
                            TextView text =  (TextView)dialog.findViewById(R.id.dialogText);
                            text.setText("Error:\n" + firebaseError.toString());
                            dialog.show();
                        }
                            else
                        {
                            TextView addGroupText = (TextView)getActivity().findViewById(R.id.GroupTxtAddGroup);
                            addGroupText.setText("");
                            addGroupText.setSelected(false);
                        }
                        }
                    });
                }
            }
        });
        return root;
    }

    @Override
    public void onViewCreated(View view, Bundle savedInstanceState) {

        super.onViewCreated(view, savedInstanceState);
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
