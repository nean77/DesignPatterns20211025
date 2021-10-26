﻿using System;
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

		public MainWindowViewModel()
		{
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

			var samples = SourceReader.ReadAllSources(_selectedFiles);

			Append(samples);

			_selectedFiles.Clear();
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