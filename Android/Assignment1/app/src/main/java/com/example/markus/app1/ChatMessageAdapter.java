package com.example.markus.app1;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by Markus Olsson on 2014-12-04.
 */
public class ChatMessageAdapter extends ArrayAdapter<ChatMessage>
{
    private LayoutInflater mLayoutInflater;
    public ChatMessageAdapter(Context context, ArrayList<ChatMessage> messages)
    {
        super(context,R.layout.message_row, messages);
        mLayoutInflater = LayoutInflater.from(context);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
         ViewHolder holder = null;

        if(convertView == null)
        {
            convertView = mLayoutInflater.inflate(R.layout.message_row, parent, false);

            holder = new ViewHolder();

            holder.name = (TextView) convertView.findViewById(R.id.name);
            holder.message = (TextView) convertView.findViewById(R.id.message);
            holder.time = (TextView) convertView.findViewById(R.id.time);

            convertView.setTag(holder);
        }
    else
        {
    holder = (ViewHolder) convertView.getTag();
        }

    holder.name.setText(getItem(position).getFrom());
    holder.message.setText(getItem(position).getMessage());
    holder.time.setText(getItem(position).getTimestamp());

    return convertView;
    }
    private class ViewHolder{
        TextView name;
        TextView message;
        TextView time;
    }
}
