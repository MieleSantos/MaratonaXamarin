using Android.App;
using Android.Widget;
using Android.OS;

namespace Exe1Modulo2
{
	[Activity(Label = "Exe1Modulo2", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			Button btnconverter = FindViewById<Button>(Resource.Id.btnconverter);
			EditText txtdolares = FindViewById<EditText>(Resource.Id.txtdolares);
			EditText txtpesos = FindViewById<EditText>(Resource.Id.txtpesos);
			double pesos, dolares;

			btnconverter.Click += delegate 
			{
				try
				{
					dolares = double.Parse(txtdolares.Text);
					pesos = dolares - 19.5;
					txtpesos.Text = pesos.ToString();
				}
				catch (System.Exception ex) 
				{
					Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
				}
			};
				

		}
	}
}

