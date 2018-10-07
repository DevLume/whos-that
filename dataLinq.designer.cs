﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Whos_that
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="data")]
	public partial class dataLinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttestTable(testTable instance);
    partial void UpdatetestTable(testTable instance);
    partial void DeletetestTable(testTable instance);
    partial void InsertusersRelTable(usersRelTable instance);
    partial void UpdateusersRelTable(usersRelTable instance);
    partial void DeleteusersRelTable(usersRelTable instance);
    partial void InsertusersTable(usersTable instance);
    partial void UpdateusersTable(usersTable instance);
    partial void DeleteusersTable(usersTable instance);
    #endregion
		
		public dataLinqDataContext() : 
				base(global::Whos_that.Properties.Settings.Default.dataConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public dataLinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dataLinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dataLinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dataLinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<testTable> testTables
		{
			get
			{
				return this.GetTable<testTable>();
			}
		}
		
		public System.Data.Linq.Table<usersRelTable> usersRelTables
		{
			get
			{
				return this.GetTable<usersRelTable>();
			}
		}
		
		public System.Data.Linq.Table<usersTable> usersTables
		{
			get
			{
				return this.GetTable<usersTable>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.testTable")]
	public partial class testTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private System.Nullable<int> _Age;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAgeChanging(System.Nullable<int> value);
    partial void OnAgeChanged();
    #endregion
		
		public testTable()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int")]
		public System.Nullable<int> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.usersRelTable")]
	public partial class usersRelTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _user1ID;
		
		private System.Nullable<int> _user2ID;
		
		private System.Nullable<bool> _approved;
		
		private System.Nullable<System.DateTime> _since;
		
		private System.Nullable<bool> _received;
        private DateTime date;

        #region Extensibility Method Definitions
        partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Onuser1IDChanging(int value);
    partial void Onuser1IDChanged();
    partial void Onuser2IDChanging(System.Nullable<int> value);
    partial void Onuser2IDChanged();
    partial void OnapprovedChanging(System.Nullable<bool> value);
    partial void OnapprovedChanged();
    partial void OnsinceChanging(System.Nullable<System.DateTime> value);
    partial void OnsinceChanged();
    partial void OnreceivedChanging(System.Nullable<bool> value);
    partial void OnreceivedChanged();
    #endregion
		
		public usersRelTable()
		{
			OnCreated();
		}

        public usersRelTable(int id, int user1ID, int user2ID, bool approved, DateTime date, bool received)
        {
            Id = id;
            this.user1ID = user1ID;
            this.user2ID = user2ID;
            this.approved = approved;
            this.date = date;
            this.received = received;
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user1ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int user1ID
		{
			get
			{
				return this._user1ID;
			}
			set
			{
				if ((this._user1ID != value))
				{
					this.Onuser1IDChanging(value);
					this.SendPropertyChanging();
					this._user1ID = value;
					this.SendPropertyChanged("user1ID");
					this.Onuser1IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user2ID", DbType="Int")]
		public System.Nullable<int> user2ID
		{
			get
			{
				return this._user2ID;
			}
			set
			{
				if ((this._user2ID != value))
				{
					this.Onuser2IDChanging(value);
					this.SendPropertyChanging();
					this._user2ID = value;
					this.SendPropertyChanged("user2ID");
					this.Onuser2IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_approved", DbType="Bit")]
		public System.Nullable<bool> approved
		{
			get
			{
				return this._approved;
			}
			set
			{
				if ((this._approved != value))
				{
					this.OnapprovedChanging(value);
					this.SendPropertyChanging();
					this._approved = value;
					this.SendPropertyChanged("approved");
					this.OnapprovedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_since", DbType="Date")]
		public System.Nullable<System.DateTime> since
		{
			get
			{
				return this._since;
			}
			set
			{
				if ((this._since != value))
				{
					this.OnsinceChanging(value);
					this.SendPropertyChanging();
					this._since = value;
					this.SendPropertyChanged("since");
					this.OnsinceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_received", DbType="Bit")]
		public System.Nullable<bool> received
		{
			get
			{
				return this._received;
			}
			set
			{
				if ((this._received != value))
				{
					this.OnreceivedChanging(value);
					this.SendPropertyChanging();
					this._received = value;
					this.SendPropertyChanged("received");
					this.OnreceivedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.usersTable")]
	public partial class usersTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _Email;
		
		private string _PassHash;
		
		private string _Gender;
		
		private System.Nullable<bool> _Online;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPassHashChanging(string value);
    partial void OnPassHashChanged();
    partial void OnGenderChanging(string value);
    partial void OnGenderChanged();
    partial void OnOnlineChanging(System.Nullable<bool> value);
    partial void OnOnlineChanged();
    #endregion
		
		public usersTable()
		{
			OnCreated();
		}

        public usersTable(int id, string name, string email, string passHash, string gender)
        {
            Id = id;
            Name = name;
            Email = email;
            PassHash = passHash;
            Gender = gender;
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PassHash", DbType="VarChar(50)")]
		public string PassHash
		{
			get
			{
				return this._PassHash;
			}
			set
			{
				if ((this._PassHash != value))
				{
					this.OnPassHashChanging(value);
					this.SendPropertyChanging();
					this._PassHash = value;
					this.SendPropertyChanged("PassHash");
					this.OnPassHashChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="Char(10)")]
		public string Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this.OnGenderChanging(value);
					this.SendPropertyChanging();
					this._Gender = value;
					this.SendPropertyChanged("Gender");
					this.OnGenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Online", DbType="Bit")]
		public System.Nullable<bool> Online
		{
			get
			{
				return this._Online;
			}
			set
			{
				if ((this._Online != value))
				{
					this.OnOnlineChanging(value);
					this.SendPropertyChanging();
					this._Online = value;
					this.SendPropertyChanged("Online");
					this.OnOnlineChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
