
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Exe2Modulo2
{
	[Activity(Label = "VistaCapital")]
	public class VistaCapital : Activity
	{
		readonly double defaultValue;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.VistaCapital);
			EditText txtCapitalM = FindViewById<EditText>(Resource.Id.txtcapitalM);
			EditText txtCapitalC = FindViewById<EditText>(Resource.Id.txtcapitalC);
			ImageView imgMexico= FindViewById<ImageView>(Resource.Id.imgMexico);
			ImageView imgColombia = FindViewById<ImageView>(Resource.Id.imgColombia);
			Button btnSair = FindViewById<Button>(Resource.Id.btnSair);

			try
			{
				txtCapitalM.Text = Intent.GetDoubleExtra("CapitalM", defaultValue).ToString();
				txtCapitalC.Text = Intent.GetDoubleExtra("CapitalC", defaultValue).ToString();
				imgMexico.SetImageResource(Resource.Drawable.mexico);
				imgColombia.SetImageResource(Resource.Drawable.colombia);
			}
			catch (Exception ex)
			{
				Toast.MakeText
						 (this, ex.Message,
						  ToastLength.Short).Show();
			}
			btnSair.Click += delegate
			{
				Process.KillProcess(Process.MyPid());
			};

		}
	}
}
