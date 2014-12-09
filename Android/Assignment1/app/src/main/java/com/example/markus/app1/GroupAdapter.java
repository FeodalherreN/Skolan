package com.example.markus.app1;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by Markus Olsson on 2014-12-03.
 */
public class GroupAdapter extends ArrayAdapter<Group>
{
    private LayoutInflater mLayoutInflater;
    public GroupAdapter(Context context, ArrayList<Group> groups)
    {
        super(context, R.layout.group_row, groups);
        mLayoutInflater = LayoutInflater.from(context);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent)
    {
        ViewHolder holder = null;

        if(convertView == null)
        {
            convertView = mLayoutInflater.inflate(R.layout.group_row, parent, false);

            holder = new ViewHolder();
            holder.name = (TextView)convertView.findViewById(R.id.groupName);

            convertView.setTag(holder);
        }
        else
        {
            holder = (ViewHolder)convertView.getTag();
        }

        holder.name.setText(getItem(position).getName());
        return convertView;
    }
    private class ViewHolder
    {
        TextView name;
    }
}
