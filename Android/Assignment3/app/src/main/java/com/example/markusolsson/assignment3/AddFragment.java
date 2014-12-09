package com.example.markusolsson.assignment3;

import android.app.Activity;
import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.Toast;

import java.util.Date;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link AddFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link AddFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class AddFragment extends Fragment {
    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;
    private IncomeAdapter myIncomeAdapter;
    private ExpensesAdapter myExpenseAdapter;

    private OnFragmentInteractionListener mListener;

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment AddFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static AddFragment newInstance(String param1, String param2) {
        AddFragment fragment = new AddFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    public AddFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View root = inflater.inflate(R.layout.fragment_add, container, false);
        Button btnadd = (Button)root.findViewById(R.id.btnAdd);
        final RadioButton btnexpense = (RadioButton)root.findViewById(R.id.radioExpense);
        final RadioButton btnincome = (RadioButton)root.findViewById(R.id.radioIncome);
        final EditText txtTitle = (EditText)root.findViewById(R.id.txtTitle);
        final EditText txtAmount = (EditText)root.findViewById(R.id.txtAmount);
        EditText txtDate = (EditText)root.findViewById(R.id.txtDate);
        btnincome.setChecked(true);
        btnincome.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
            btnexpense.setChecked(false);
            }
        });
        btnexpense.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
            btnincome.setChecked(false);
            }
        });
        btnadd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(btnincome.isChecked())
                {
                    myIncomeAdapter = new IncomeAdapter(root.getContext());
                    String title = txtTitle.getText().toString();
                    int amount = Integer.parseInt(txtAmount.getText().toString());
                    myIncomeAdapter.openToWrite();
                    myIncomeAdapter.insert(title, amount);
                    myIncomeAdapter.close();
                    Toast.makeText(root.getContext(), title + " added to incomes.", Toast.LENGTH_SHORT).show();
                }
                if(btnexpense.isChecked())
                {
                    myExpenseAdapter = new ExpensesAdapter(root.getContext());
                    String title = txtTitle.getText().toString();
                    int amount = Integer.parseInt(txtAmount.getText().toString());
                    myExpenseAdapter.openToWrite();
                    myExpenseAdapter.insert(title, amount);
                    myExpenseAdapter.close();
                    Toast.makeText(root.getContext(), title + " added to expenses.", Toast.LENGTH_SHORT).show();
                }
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
