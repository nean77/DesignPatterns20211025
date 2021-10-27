using System;
using System.Windows;
using PbLab.DesignPatterns.Audit;
using PbLab.DesignPatterns.Messaging;
using PbLab.DesignPatterns.Services;
using PbLab.DesignPatterns.Tools;
using PbLab.DesignPatterns.ViewModels;

namespace PbLab.DesignPatterns
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var messenger = new Messenger();

			var fileSink = new FileSink($"log.{DateTime.Now.AsFileName()}.txt");

			messenger.Subscribe(fileSink);

			DataContext = new MainWindowViewModel(new LoggerFactory(), messenger);
		}
	}
}
