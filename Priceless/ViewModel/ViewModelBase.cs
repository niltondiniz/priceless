﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Priceless
{
	public class ViewModelBase : IDisposable
	{
		private SQLite.Net.SQLiteConnection _conexao;

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

		public List<T> GetLista<T>() where T : class
		{
			var lista = _conexao.Table<T>().ToList();
			return lista;
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
