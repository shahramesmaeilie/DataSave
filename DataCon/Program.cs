using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataCon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string code, name, family, phone;
                int se, selection,SB;
                Console.WriteLine("Select one of the Cases: \n1-Save \n2-Search \n3-Delete \n4-Edit \n5-Exit");
                se = int.Parse(Console.ReadLine());
                if (se == 1)
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = "Data Source=(local);Initial Catalog=Meee;Integrated Security=True";
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("insert into tbluser values(@c,@n,@f,@ph)", conn);
                        Console.WriteLine("Enter the Code: ");
                        code = Console.ReadLine();
                        cmd.Parameters.AddWithValue("@c", code);
                        Console.WriteLine("==================================");
                        Console.WriteLine("Enter the Name: ");
                        name = Console.ReadLine();
                        cmd.Parameters.AddWithValue("@n", name);
                        Console.WriteLine("==================================");
                        Console.WriteLine("Enter the Family:  ");
                        family = Console.ReadLine();
                        cmd.Parameters.AddWithValue("@f", family);
                        Console.WriteLine("==================================");
                        Console.WriteLine("Enter the Phone: " +
                            "");
                        phone = Console.ReadLine();
                        cmd.Parameters.AddWithValue("@ph", phone);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("All Data Saved Successfully!!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        conn.Close();
                    }
                }
                else if (se == 2)
                {
                    Console.WriteLine("Searching by : 1-Code \t2-Name \t3-Mobile");
                    SB=int.Parse(Console.ReadLine());
                    if (SB == 1) { 
                    Console.WriteLine("Enter the Code of Person You're Searching : ");

                        using (SqlConnection conn = new SqlConnection())
                        {
                            conn.ConnectionString = "Data Source=(local);Initial Catalog=Meee;Integrated Security=True";
                            conn.Open();
                            code = Console.ReadLine();
                            SqlCommand cmd = new SqlCommand("select * from tbluser where code=@c", conn);
                            cmd.Parameters.Add(new SqlParameter("@c", code));
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                //Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                                while (r.Read())
                                {
                                    Console.WriteLine(String.Format("Code : {0} \t Name : {1} \t Family : {2} \t Phone : {3}",
                                        r[0], r[1], r[2], r[3]));
                                }
                                r.Close();
                            }
                            conn.Close();
                        }
                    }
                    else if (SB == 2)
                    {
                        Console.WriteLine("Enter the Name of Person You're Searching : ");

                        using (SqlConnection conn = new SqlConnection())
                        {
                            conn.ConnectionString = "Data Source=(local);Initial Catalog=Meee;Integrated Security=True";
                            conn.Open();
                            name = Console.ReadLine();
                            SqlCommand cmd = new SqlCommand("select * from tbluser where name=@n", conn);
                            cmd.Parameters.Add(new SqlParameter("@n", name));
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                //Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                                while (r.Read())
                                {
                                    Console.WriteLine(String.Format("Code : {0} \t Name : {1} \t Family : {2} \t Phone : {3}",
                                        r[0], r[1], r[2], r[3]));
                                }
                                r.Close();
                            }
                            conn.Close();
                        }
                    }
                    else if (SB == 3)
                    {
                        Console.WriteLine("Enter the Mobile of Person You're Searching : ");

                        using (SqlConnection conn = new SqlConnection())
                        {
                            conn.ConnectionString = "Data Source=(local);Initial Catalog=Meee;Integrated Security=True";
                            conn.Open();
                            phone = Console.ReadLine();
                            SqlCommand cmd = new SqlCommand("select * from tbluser where phone=@ph", conn);
                            cmd.Parameters.Add(new SqlParameter("@ph", phone));
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                //Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                                while (r.Read())
                                {
                                    Console.WriteLine(String.Format("Code : {0} \t Name : {1} \t Family : {2} \t Phone : {3}",
                                        r[0], r[1], r[2], r[3]));
                                }
                                r.Close();
                            }
                            conn.Close();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Enter one of the mentioned ways!!");
                    }
                }
                else if (se == 3)
                {
                    Console.WriteLine("Enter the Code of Person You Want to Delete : ");

                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = "Data Source=(local);Initial Catalog=Meee;Integrated Security=True";
                        conn.Open();
                        code = Console.ReadLine();
                        SqlCommand cmd = new SqlCommand("delete from tbluser where code=@c", conn);
                        cmd.Parameters.AddWithValue("@c", code);
                        try
                            {
                                cmd.ExecuteNonQuery();
                                Console.WriteLine("All Data with this Code Deleted!!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        conn.Close();
                    }
                }
                else if (se == 4)
                {
                    Console.WriteLine("Enter the Code of Person You Want to Edit : ");

                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = "Data Source=(local);Initial Catalog=Meee;Integrated Security=True";
                        conn.Open();
                        code = Console.ReadLine();
                        //SqlCommand cmd = new SqlCommand("update  tbluser set name=@n , family= @f, phone=@ph where code=@c", conn);
                       // cmd.Parameters.AddWithValue("@c", code);
                        Console.WriteLine("Which Information of the Person You Want to Edit?");
                        Console.WriteLine("1-Name \t2-Family \t3-Phone");
                        selection=int.Parse(Console.ReadLine());
                        if(selection==1)
                        {
                            Console.WriteLine("Edit the Name: ");
                            name = Console.ReadLine();
                            SqlCommand cmd1 = new SqlCommand("update  tbluser set name=@n where code=@c", conn);
                            cmd1.Parameters.AddWithValue("@c", code);
                            cmd1.Parameters.AddWithValue("@n", name);
                            try
                            {
                                cmd1.ExecuteNonQuery();
                                Console.WriteLine("Edition done Successfully!!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if(selection==2)
                        {
                            SqlCommand cmd2 = new SqlCommand("update  tbluser set  family= @f where code=@c", conn);
                            cmd2.Parameters.AddWithValue("@c", code);
                            Console.WriteLine("Edit the Family:  ");
                            family = Console.ReadLine();
                            cmd2.Parameters.AddWithValue("@f", family);
                            try
                            {
                                cmd2.ExecuteNonQuery();
                                Console.WriteLine("Edition done Successfully!!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if(selection ==3)
                        {
                            SqlCommand cmd3 = new SqlCommand("update  tbluser set  phone=@ph where code=@c", conn);
                            cmd3.Parameters.AddWithValue("@c", code);
                            Console.WriteLine("Edit the Phone: ");
                            phone = Console.ReadLine();
                            cmd3.Parameters.AddWithValue("@ph", phone);
                            try
                            {
                                cmd3.ExecuteNonQuery();
                                Console.WriteLine("Edition done Successfully!!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please Select a Parametre!! ");
                        }
                        conn.Close();
                    }
                }
                else
                {
                    Console.Beep();
                    
                }
       
                Console.WriteLine("Press any Key to New .....");
                Console.ReadKey();
            }
        }
    }
}
