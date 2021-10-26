using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;
using PbLab.DesignPatterns.Model;
using PbLab.DesignPatterns.Services;
using PbLab.DesignPatterns.Tools;

namespace PbLab.DesignPatterns.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
        private readonly ObservableCollection<string> _selectedFiles = new ObservableCollection<string>();
		private readonly ObservableCollection<Sample> _samples = new ObservableCollection<Sample>();

		private readonly ObjectsPool<ISamplesReader> _readersShelf;

		public MainWindowViewModel(ObjectsPool<ISamplesReader> readersShelf)
		{
			_readersShelf = readersShelf;

			SelectedFiles = new ReadOnlyObservableCollection<string>(_selectedFiles);
			Samples = new ReadOnlyObservableCollection<Sample>(_samples);
			OpenFileCmd = new RelayCommand(OnOpenFile, CanOpenFile);
			RemoveFileCmd = new RelayCommand<string>(OnRemoveFile, CanRemoveFile);
			ReadFileCmd = new RelayCommand(OnReadFiles, CanReadFiles);
		}

		private bool CanReadFiles() => _selectedFiles.Any();

		private void OnReadFiles()
		{
			_samples.Clear();

			var reportTemplate = new ReportPrototype(DateTime.Now);

			var reports = new List<string>();

			foreach (var file in _selectedFiles)
			{
				var stats = new StatsBuilder(file);

				var reader = _readersShelf.Borrow(new FileInfo(file).Extension);

				IEnumerable<Sample> samples;
				var stopper = new Stopwatch();
				stopper.Start();
				using (StreamReader stream = File.OpenText(file))
				{
					samples = reader.Read(stream);
				}

				stopper.Stop();

				_readersShelf.Release(reader);

				Append(samples);

				stats.AddDuration(stopper.Elapsed);
				stats.AddCount((uint)samples.Count());

				reports.Add(reportTemplate.Clone(stats.Build()));
			}

			Store(reports);

			_selectedFiles.Clear();
		}

		private void Store(List<string> reports)
		{
			throw new NotImplementedException();
		}

		private bool CanRemoveFile(string arg) => true;

		private bool CanOpenFile() => true;

		private void OnRemoveFile(string file)
		{
			_selectedFiles.Remove(file);
			ReadFileCmd.RaiseCanExecuteChanged();
		}

		private void OnOpenFile()
		{
			var dialog = new OpenFileDialog();
			var result = dialog.ShowDialog();
			if (result == false)
			{
				return;
			}

			_selectedFiles.Add(dialog.FileName);
			ReadFileCmd.RaiseCanExecuteChanged();
		}

		public ReadOnlyObservableCollection<string> SelectedFiles { get; }

		public ReadOnlyObservableCollection<Sample> Samples { get; }

		public RelayCommand OpenFileCmd { get; private set; }

		public RelayCommand<string> RemoveFileCmd { get; private set; }

		public RelayCommand ReadFileCmd { get; private set; }

		private void Append(IEnumerable<Sample> samples)
		{
			foreach (var item in samples)
			{
				_samples.Add(item);
			}
		}
	}
}