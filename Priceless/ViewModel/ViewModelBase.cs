﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using Xamarin.Forms;

namespace Priceless
{
	public class ViewModelBase : IDisposable
	{
		private SQLite.Net.SQLiteConnection _conexao;

		private Dictionary<string, object> properties = new Dictionary<string, object>();

		public void Dispose()
		{
			_conexao.Dispose();
		}

		public ViewModelBase()
		{
			var config = DependencyService.Get<IConfig>();
			_conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "bancodados3.db3"));
			_conexao.CreateTable<ProdutoCompra>();
			_conexao.CreateTable<Settings>();
		}

		public void Insert<T>(object objeto)
		{
			_conexao.Insert((T)objeto);
		}

		public List<ProdutoCompra> Listar()
		{
			var lista = _conexao.Table<ProdutoCompra>().ToList();
			return lista;
		}


		public Settings GetSettings()
		{
			try
			{
				var settings = _conexao.Table<Settings>().ToList();
				if (settings != null)
				{
					return settings[0];
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				return null;
			}

		}

		public void Delete<T>(object objeto)
		{
			_conexao.Delete(objeto);
		}

		public void Update<T>(object objeto)
		{
			_conexao.Update((T)objeto);
		}
	}
}
