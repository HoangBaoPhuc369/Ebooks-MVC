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

namespace Ebooks.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="EBOOKS")]
	public partial class MyDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBook(Book instance);
    partial void UpdateBook(Book instance);
    partial void DeleteBook(Book instance);
    partial void Insertcategory(category instance);
    partial void Updatecategory(category instance);
    partial void Deletecategory(category instance);
    partial void Insertcustomer(customer instance);
    partial void Updatecustomer(customer instance);
    partial void Deletecustomer(customer instance);
    partial void Insertorder_list(order_list instance);
    partial void Updateorder_list(order_list instance);
    partial void Deleteorder_list(order_list instance);
    partial void Insertorder(order instance);
    partial void Updateorder(order instance);
    partial void Deleteorder(order instance);
    partial void Insertuser(user instance);
    partial void Updateuser(user instance);
    partial void Deleteuser(user instance);
    #endregion
		
		public MyDataDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["EBOOKSConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MyDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Book> Books
		{
			get
			{
				return this.GetTable<Book>();
			}
		}
		
		public System.Data.Linq.Table<category> categories
		{
			get
			{
				return this.GetTable<category>();
			}
		}
		
		public System.Data.Linq.Table<customer> customers
		{
			get
			{
				return this.GetTable<customer>();
			}
		}
		
		public System.Data.Linq.Table<order_list> order_lists
		{
			get
			{
				return this.GetTable<order_list>();
			}
		}
		
		public System.Data.Linq.Table<order> orders
		{
			get
			{
				return this.GetTable<order>();
			}
		}
		
		public System.Data.Linq.Table<user> users
		{
			get
			{
				return this.GetTable<user>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Book")]
	public partial class Book : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Nullable<int> _category_id;
		
		private string _title;
		
		private string _author;
		
		private string _description;
		
		private System.Nullable<int> _qty;
		
		private System.Nullable<double> _price;
		
		private string _image_path;
		
		private System.Nullable<System.DateTime> _date_create;
		
		private EntitySet<order_list> _order_lists;
		
		private EntityRef<category> _category;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Oncategory_idChanging(System.Nullable<int> value);
    partial void Oncategory_idChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OnauthorChanging(string value);
    partial void OnauthorChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnqtyChanging(System.Nullable<int> value);
    partial void OnqtyChanged();
    partial void OnpriceChanging(System.Nullable<double> value);
    partial void OnpriceChanged();
    partial void Onimage_pathChanging(string value);
    partial void Onimage_pathChanged();
    partial void Ondate_createChanging(System.Nullable<System.DateTime> value);
    partial void Ondate_createChanged();
    #endregion
		
		public Book()
		{
			this._order_lists = new EntitySet<order_list>(new Action<order_list>(this.attach_order_lists), new Action<order_list>(this.detach_order_lists));
			this._category = default(EntityRef<category>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category_id", DbType="Int")]
		public System.Nullable<int> category_id
		{
			get
			{
				return this._category_id;
			}
			set
			{
				if ((this._category_id != value))
				{
					if (this._category.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Oncategory_idChanging(value);
					this.SendPropertyChanging();
					this._category_id = value;
					this.SendPropertyChanged("category_id");
					this.Oncategory_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="NVarChar(200)")]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_author", DbType="NVarChar(50)")]
		public string author
		{
			get
			{
				return this._author;
			}
			set
			{
				if ((this._author != value))
				{
					this.OnauthorChanging(value);
					this.SendPropertyChanging();
					this._author = value;
					this.SendPropertyChanged("author");
					this.OnauthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(4000)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_qty", DbType="Int")]
		public System.Nullable<int> qty
		{
			get
			{
				return this._qty;
			}
			set
			{
				if ((this._qty != value))
				{
					this.OnqtyChanging(value);
					this.SendPropertyChanging();
					this._qty = value;
					this.SendPropertyChanged("qty");
					this.OnqtyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="Float")]
		public System.Nullable<double> price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_image_path", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string image_path
		{
			get
			{
				return this._image_path;
			}
			set
			{
				if ((this._image_path != value))
				{
					this.Onimage_pathChanging(value);
					this.SendPropertyChanging();
					this._image_path = value;
					this.SendPropertyChanged("image_path");
					this.Onimage_pathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_create", DbType="DateTime")]
		public System.Nullable<System.DateTime> date_create
		{
			get
			{
				return this._date_create;
			}
			set
			{
				if ((this._date_create != value))
				{
					this.Ondate_createChanging(value);
					this.SendPropertyChanging();
					this._date_create = value;
					this.SendPropertyChanged("date_create");
					this.Ondate_createChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_order_list", Storage="_order_lists", ThisKey="id", OtherKey="id_book")]
		public EntitySet<order_list> order_lists
		{
			get
			{
				return this._order_lists;
			}
			set
			{
				this._order_lists.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="category_Book", Storage="_category", ThisKey="category_id", OtherKey="id", IsForeignKey=true)]
		public category category
		{
			get
			{
				return this._category.Entity;
			}
			set
			{
				category previousValue = this._category.Entity;
				if (((previousValue != value) 
							|| (this._category.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._category.Entity = null;
						previousValue.Books.Remove(this);
					}
					this._category.Entity = value;
					if ((value != null))
					{
						value.Books.Add(this);
						this._category_id = value.id;
					}
					else
					{
						this._category_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("category");
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
		
		private void attach_order_lists(order_list entity)
		{
			this.SendPropertyChanging();
			entity.Book = this;
		}
		
		private void detach_order_lists(order_list entity)
		{
			this.SendPropertyChanging();
			entity.Book = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.categories")]
	public partial class category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<Book> _Books;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public category()
		{
			this._Books = new EntitySet<Book>(new Action<Book>(this.attach_Books), new Action<Book>(this.detach_Books));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="category_Book", Storage="_Books", ThisKey="id", OtherKey="category_id")]
		public EntitySet<Book> Books
		{
			get
			{
				return this._Books;
			}
			set
			{
				this._Books.Assign(value);
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
		
		private void attach_Books(Book entity)
		{
			this.SendPropertyChanging();
			entity.category = this;
		}
		
		private void detach_Books(Book entity)
		{
			this.SendPropertyChanging();
			entity.category = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.customer")]
	public partial class customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _username;
		
		private string _password;
		
		private string _email;
		
		private string _address;
		
		private string _contact;
		
		private System.Nullable<System.DateTime> _date_create;
		
		private EntitySet<order> _orders;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OncontactChanging(string value);
    partial void OncontactChanged();
    partial void Ondate_createChanging(System.Nullable<System.DateTime> value);
    partial void Ondate_createChanged();
    #endregion
		
		public customer()
		{
			this._orders = new EntitySet<order>(new Action<order>(this.attach_orders), new Action<order>(this.detach_orders));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(100)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(50)")]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_contact", DbType="VarChar(50)")]
		public string contact
		{
			get
			{
				return this._contact;
			}
			set
			{
				if ((this._contact != value))
				{
					this.OncontactChanging(value);
					this.SendPropertyChanging();
					this._contact = value;
					this.SendPropertyChanged("contact");
					this.OncontactChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_create", DbType="DateTime")]
		public System.Nullable<System.DateTime> date_create
		{
			get
			{
				return this._date_create;
			}
			set
			{
				if ((this._date_create != value))
				{
					this.Ondate_createChanging(value);
					this.SendPropertyChanging();
					this._date_create = value;
					this.SendPropertyChanged("date_create");
					this.Ondate_createChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="customer_order", Storage="_orders", ThisKey="id", OtherKey="id_customer")]
		public EntitySet<order> orders
		{
			get
			{
				return this._orders;
			}
			set
			{
				this._orders.Assign(value);
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
		
		private void attach_orders(order entity)
		{
			this.SendPropertyChanging();
			entity.customer = this;
		}
		
		private void detach_orders(order entity)
		{
			this.SendPropertyChanging();
			entity.customer = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.order_list")]
	public partial class order_list : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _id_order;
		
		private int _id_book;
		
		private System.Nullable<int> _amount;
		
		private System.Nullable<double> _unit_price;
		
		private EntityRef<Book> _Book;
		
		private EntityRef<order> _order;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onid_orderChanging(int value);
    partial void Onid_orderChanged();
    partial void Onid_bookChanging(int value);
    partial void Onid_bookChanged();
    partial void OnamountChanging(System.Nullable<int> value);
    partial void OnamountChanged();
    partial void Onunit_priceChanging(System.Nullable<double> value);
    partial void Onunit_priceChanged();
    #endregion
		
		public order_list()
		{
			this._Book = default(EntityRef<Book>);
			this._order = default(EntityRef<order>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_order", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id_order
		{
			get
			{
				return this._id_order;
			}
			set
			{
				if ((this._id_order != value))
				{
					if (this._order.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_orderChanging(value);
					this.SendPropertyChanging();
					this._id_order = value;
					this.SendPropertyChanged("id_order");
					this.Onid_orderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_book", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id_book
		{
			get
			{
				return this._id_book;
			}
			set
			{
				if ((this._id_book != value))
				{
					if (this._Book.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_bookChanging(value);
					this.SendPropertyChanging();
					this._id_book = value;
					this.SendPropertyChanged("id_book");
					this.Onid_bookChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_amount", DbType="Int")]
		public System.Nullable<int> amount
		{
			get
			{
				return this._amount;
			}
			set
			{
				if ((this._amount != value))
				{
					this.OnamountChanging(value);
					this.SendPropertyChanging();
					this._amount = value;
					this.SendPropertyChanged("amount");
					this.OnamountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_unit_price", DbType="Float")]
		public System.Nullable<double> unit_price
		{
			get
			{
				return this._unit_price;
			}
			set
			{
				if ((this._unit_price != value))
				{
					this.Onunit_priceChanging(value);
					this.SendPropertyChanging();
					this._unit_price = value;
					this.SendPropertyChanged("unit_price");
					this.Onunit_priceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_order_list", Storage="_Book", ThisKey="id_book", OtherKey="id", IsForeignKey=true)]
		public Book Book
		{
			get
			{
				return this._Book.Entity;
			}
			set
			{
				Book previousValue = this._Book.Entity;
				if (((previousValue != value) 
							|| (this._Book.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Book.Entity = null;
						previousValue.order_lists.Remove(this);
					}
					this._Book.Entity = value;
					if ((value != null))
					{
						value.order_lists.Add(this);
						this._id_book = value.id;
					}
					else
					{
						this._id_book = default(int);
					}
					this.SendPropertyChanged("Book");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="order_order_list", Storage="_order", ThisKey="id_order", OtherKey="id", IsForeignKey=true)]
		public order order
		{
			get
			{
				return this._order.Entity;
			}
			set
			{
				order previousValue = this._order.Entity;
				if (((previousValue != value) 
							|| (this._order.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._order.Entity = null;
						previousValue.order_lists.Remove(this);
					}
					this._order.Entity = value;
					if ((value != null))
					{
						value.order_lists.Add(this);
						this._id_order = value.id;
					}
					else
					{
						this._id_order = default(int);
					}
					this.SendPropertyChanged("order");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.orders")]
	public partial class order : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Nullable<bool> _paid;
		
		private System.Nullable<bool> _status;
		
		private System.Nullable<System.DateTime> _date_create;
		
		private System.Nullable<System.DateTime> _date_delivery;
		
		private System.Nullable<int> _id_customer;
		
		private EntitySet<order_list> _order_lists;
		
		private EntityRef<customer> _customer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnpaidChanging(System.Nullable<bool> value);
    partial void OnpaidChanged();
    partial void OnstatusChanging(System.Nullable<bool> value);
    partial void OnstatusChanged();
    partial void Ondate_createChanging(System.Nullable<System.DateTime> value);
    partial void Ondate_createChanged();
    partial void Ondate_deliveryChanging(System.Nullable<System.DateTime> value);
    partial void Ondate_deliveryChanged();
    partial void Onid_customerChanging(System.Nullable<int> value);
    partial void Onid_customerChanged();
    #endregion
		
		public order()
		{
			this._order_lists = new EntitySet<order_list>(new Action<order_list>(this.attach_order_lists), new Action<order_list>(this.detach_order_lists));
			this._customer = default(EntityRef<customer>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_paid", DbType="Bit")]
		public System.Nullable<bool> paid
		{
			get
			{
				return this._paid;
			}
			set
			{
				if ((this._paid != value))
				{
					this.OnpaidChanging(value);
					this.SendPropertyChanging();
					this._paid = value;
					this.SendPropertyChanged("paid");
					this.OnpaidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="Bit")]
		public System.Nullable<bool> status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_create", DbType="DateTime")]
		public System.Nullable<System.DateTime> date_create
		{
			get
			{
				return this._date_create;
			}
			set
			{
				if ((this._date_create != value))
				{
					this.Ondate_createChanging(value);
					this.SendPropertyChanging();
					this._date_create = value;
					this.SendPropertyChanged("date_create");
					this.Ondate_createChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_delivery", DbType="DateTime")]
		public System.Nullable<System.DateTime> date_delivery
		{
			get
			{
				return this._date_delivery;
			}
			set
			{
				if ((this._date_delivery != value))
				{
					this.Ondate_deliveryChanging(value);
					this.SendPropertyChanging();
					this._date_delivery = value;
					this.SendPropertyChanged("date_delivery");
					this.Ondate_deliveryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_customer", DbType="Int")]
		public System.Nullable<int> id_customer
		{
			get
			{
				return this._id_customer;
			}
			set
			{
				if ((this._id_customer != value))
				{
					if (this._customer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_customerChanging(value);
					this.SendPropertyChanging();
					this._id_customer = value;
					this.SendPropertyChanged("id_customer");
					this.Onid_customerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="order_order_list", Storage="_order_lists", ThisKey="id", OtherKey="id_order")]
		public EntitySet<order_list> order_lists
		{
			get
			{
				return this._order_lists;
			}
			set
			{
				this._order_lists.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="customer_order", Storage="_customer", ThisKey="id_customer", OtherKey="id", IsForeignKey=true)]
		public customer customer
		{
			get
			{
				return this._customer.Entity;
			}
			set
			{
				customer previousValue = this._customer.Entity;
				if (((previousValue != value) 
							|| (this._customer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._customer.Entity = null;
						previousValue.orders.Remove(this);
					}
					this._customer.Entity = value;
					if ((value != null))
					{
						value.orders.Add(this);
						this._id_customer = value.id;
					}
					else
					{
						this._id_customer = default(Nullable<int>);
					}
					this.SendPropertyChanged("customer");
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
		
		private void attach_order_lists(order_list entity)
		{
			this.SendPropertyChanging();
			entity.order = this;
		}
		
		private void detach_order_lists(order_list entity)
		{
			this.SendPropertyChanging();
			entity.order = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.users")]
	public partial class user : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _username;
		
		private string _password;
		
		private System.Nullable<byte> _type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OntypeChanging(System.Nullable<byte> value);
    partial void OntypeChanged();
    #endregion
		
		public user()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="VarChar(200)")]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(200)")]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="TinyInt")]
		public System.Nullable<byte> type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this.OntypeChanging(value);
					this.SendPropertyChanging();
					this._type = value;
					this.SendPropertyChanged("type");
					this.OntypeChanged();
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
