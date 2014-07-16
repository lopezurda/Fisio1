using System;
using System.Web;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using log4net;
using Web.Dominio;
using Web.DAO;
using NHibernate;

namespace Web.Salas
{
	public class InicioSalasController
	{
		
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod ().DeclaringType);
		
		private const string ConstDataDridItemsName = "InicioSalaDataGridItems";
        private readonly int _recordCount;
		
		public string Filter { get; set; }
		
		public List<Sala> SalaItems { get; set; }
//        {
//            get
//            {
//                return CalendarItemsData.FindAll(delegate(CalendarItem item)
//                                                     {
//                                                         var hasFilter = !string.IsNullOrEmpty(Filter) &&
//                                                                          Filter.ToLower() != "search";
//
//                                                         if (hasFilter)
//                                                         {
//                                                             return
//                                                                 (item.ActivityName.ToLower().IndexOf(Filter.ToLower()) !=
//                                                                  -1 ||
//                                                                  item.ContactPerson.ToLower().IndexOf(Filter.ToLower()) !=
//                                                                  -1) &&
//                                                                 !item.IsDeleted;
//                                                         }
//
//                                                         return !item.IsDeleted;
//                                                     });
//            }
//        }
		
		
		//Constructor
		public InicioSalasController ()
		{
			log.Info ("Inicio carga de salas");
		
			NHibernateSessionManager sessionManager = new NHibernateSessionManager ();
			IDao<Sala > salaDao = new Dao<Sala> (sessionManager); 
			ISession session=salaDao.GetSession();
			IList<Sala> salasRecuperadas=session.CreateCriteria<Sala>().List<Sala>();
			SalaItems=salasRecuperadas.Cast<Sala>().ToList();;
//salasRecuperadas.Cast[T]().ToList();
			
		}
		
		
//		public InicioSalasController ():this(25)
//		{
//		}
		
//		public InicioSalasController(int numberOfRecords)
//        {
//            Filter = string.Empty;
//            _recordCount = numberOfRecords;
//        }
		
		public DataTable ListAsDataTable()
        {
            return ToDataTable(List());
        }

        private List<Sala> SalaItemsData
        {
            get
            {
                if (HttpContext.Current.Session[ConstDataDridItemsName] == null)
                    HttpContext.Current.Session[ConstDataDridItemsName] = SalaItems;

                return HttpContext.Current.Session[ConstDataDridItemsName] as List<Sala>;
            }
        }
		
		
		public List<Sala> List()
        {
            return SalaItems;
        }
		
		public List<Sala> List(int startRow, int pageSize)
        {
            return SalaItems.GetRange(startRow, pageSize);
        }
		
		public static void Reset()
        {
            HttpContext.Current.Session[ConstDataDridItemsName] = null;
        }
		
//		public static List<CalendarItem> CreatItems(int count)
//        {
//            return CreateItems(count, Math.Max(count, 3) / 3);
//        }
//		
//		
//		public static List<CalendarItem> CreateItems(int count, int personCount)
//        {
//            var firstnames = new[] { "Tom", "Erik", "Bill", "Gary", "Lucy", "Cindy", "Jenna", "Joel", "Scott", "Myron", "Nina", "Isabelle", "Bob" };
//            var lastnames = new[] { "Wilkins", "Farraday", "Nielsen", "Olsen", "Meyers", "Croft", "Anderson", "Fitzgerald", "Diaz", "Hopkins", "Scholes" };
//
//            //int personCount = Math.Max(count, 3) / 3;
//            var names = new string[personCount];
//            for (var i = 0; i < personCount; i++)
//                names[i] = firstnames[Rnd.Next(0, firstnames.Length)] + " " +
//                           lastnames[Rnd.Next(0, lastnames.Length)];
//
//            var tasks = new[]
//                            {
//                                "Code Review", "Attend Seminar", "Fix Bugs", "Refactor Code", "Deliver speech",
//                                "Morning meeting",
//                                "Interview", "Business lunch", "Staff meeting", "Design Architecture",
//                                "Create Unit Tests", "Write Blog", "Customer meeting",
//                                "Development", "Development", "Development", "Development", "Quality Assurance",
//                                "Read newspapers", "Sales Presentation"
//                            };
//
//            var id = 0;
//            var tmp = new List<CalendarItem>();
//
//            for (var i = 0; i < count; i++)
//                tmp.Add(new CalendarItem(tasks[Rnd.Next(0, tasks.Length)], GetRandomDateTime(),
//                                         names[Rnd.Next(0, names.Length)], ++id, Rnd.Next(1, 2)));
//
//            return tmp;
//        }
//		
//		
//       public void Add(CalendarItem item)
//        {
//            CalendarItemsData.Add(item);
//        }









        public int GetCount()
        {
            return SalaItems.Count;
        }

        public int GetNextId()
        {
            var maxId = SalaItemsData.Aggregate(0, (current, salaItem) => Math.Max(current, salaItem.Id));

            return ++maxId;
        }

//        public List<Sala> GetDeletedItems()
//        {
//           return SalaItemsData.FindAll(index => index.IsDeleted);
//        }

//        public List<Sala> GetByDate(DateTime date)
//        {
//            return SalaItems.FindAll(index => index.ActivityDate.Day == date.Day &&
//                                                  index.ActivityDate.Month == date.Month);
//        }

        public Sala GetById(int id)
        {
            return SalaItemsData.Find(index => index.Id == id);
        }

//        private void SetDeleteStatus(int id, bool deleted)
//        {
//            var found = GetById(id);
//
//            if (found != null)
//                found.IsDeleted = deleted;
//
//        }

//        public void Delete(int id)
//        {
//            SetDeleteStatus(id, true);
//        }
//        
//        public void Delete(Sala item)
//        {
//            Delete(item.Id);
//        }
//
//        public void UnDelete(int id)
//        {
//            SetDeleteStatus(id, false);
//        }

//        public void Update(int id, int status, string contactPerson, string activityName, bool isChecked)
//        {
//            var item = GetById(id);
//            item.Status = status;
//            item.ContactPerson = contactPerson;
//            item.ActivityName = activityName;
//            item.IsChecked = isChecked;
//        }

        public void SortByActivityName(bool ascending)
        {
//            CalendarItemsData.Sort(
//                (left, right) => ascending
//                                     ? left.ActivityName.CompareTo(right.ActivityName)
//                                     : right.ActivityName.CompareTo(left.ActivityName));
        }

        public void SortByActivityDate(bool ascending)
        {
//            CalendarItemsData.Sort(
//                (left, right) => ascending
//                                     ? left.ActivityDate.CompareTo(right.ActivityDate)
//                                     : right.ActivityDate.CompareTo(left.ActivityDate));
        }

        public void SortByContactPerson(bool ascending)
        {
//            CalendarItemsData.Sort(
//                (left, right) => ascending
//                                     ? left.ContactPerson.CompareTo(right.ContactPerson)
//                                     : right.ContactPerson.CompareTo(left.ContactPerson));
        }

        public void Sort(bool ascending, string sortBy)
        {
//            switch (sortBy.ToLower())
//            {
//                case "task":
//                    SortByActivityName(ascending);
//                    break;
//
//                case "due":
//                    SortByActivityDate(ascending);
//                    break;
//
//                case "who":
//                    SortByContactPerson(ascending);
//                    break;
//
//                case "done":
//                    SortByStatus(ascending);
//                    break;
//
//                case "is difficult":
//                    SortByChecked(ascending);
//                    break;
//            }
        }

        public void SortByStatus(bool ascending)
        {
//            CalendarItemsData.Sort(
//                (left, right) => ascending ? left.Status.CompareTo(right.Status) : right.Status.CompareTo(left.Status));
        }

        public void SortByChecked(bool ascending)
        {
//            CalendarItemsData.Sort(
//                (left, right) => ascending
//                                     ? left.IsChecked.CompareTo(right.IsChecked)
//                                     : right.IsChecked.CompareTo(left.IsChecked));

        }



//        private static DateTime GetRandomDateTime()
//        {
//            return DateTime.Now.AddDays(Rnd.Next(-3, 3)).AddHours(Rnd.Next(-8, 8)).AddMinutes(Rnd.Next(-60, 60));
//        }
//
//        private static readonly Random Rnd = new Random();

		        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            DataTable tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
                tb.Columns.Add(prop.Name, prop.PropertyType);

            foreach (T item in items)
            {
                object[] values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item, null);

                tb.Rows.Add(values);
            }

            return tb;
        }

		
	}
}

