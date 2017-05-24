using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace SafeDeal.Android.Activities
{
    class RecyclerAdapter1 : RecyclerView.Adapter
    {
        public event EventHandler<RecyclerAdapter1ClickEventArgs> ItemClick;
        public event EventHandler<RecyclerAdapter1ClickEventArgs> ItemLongClick;
        string[] items;

        public RecyclerAdapter1(string[] data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.RecyclerWithAdapter;
            itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            var vh = new RecyclerAdapter1ViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as RecyclerAdapter1ViewHolder;
            //holder.TextView.Text = items[position];
        }

        public override int ItemCount => items.Length;

        void OnClick(RecyclerAdapter1ClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(RecyclerAdapter1ClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class RecyclerAdapter1ViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }


        public RecyclerAdapter1ViewHolder(View itemView, Action<RecyclerAdapter1ClickEventArgs> clickListener,
                            Action<RecyclerAdapter1ClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            itemView.Click += (sender, e) => clickListener(new RecyclerAdapter1ClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new RecyclerAdapter1ClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class RecyclerAdapter1ClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}