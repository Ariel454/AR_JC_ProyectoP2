using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class VistaLog : ContentPage
{
	public VistaLog()
	{
		InitializeComponent();
	}

    public async void OnGetButtonClicked(object sender, EventArgs args)
    {

        List<Log> logs = await App.LogRepo.GetAllLogs();
        logIds.ItemsSource = logs;
        logList.ItemsSource = logs;
        logFechas.ItemsSource = logs;
    }
}