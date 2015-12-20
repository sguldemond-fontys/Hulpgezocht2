using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using Oracle.DataAccess.Types;

namespace HulpGezocht
{
    public static class Database
    {
        static string connectionstring = "Data Source=localhost; User Id=system; password=ytcazk";
        static OracleConnection connection;
        static OracleCommand cmd = new OracleCommand() { InitialLONGFetchSize = -1 };
        static OracleDataReader reader;
        static string query = string.Empty;
        static int permission = 4;

        #region Portal
        public static bool ConnectionCheck()
        {
            try
            {
                connection = new OracleConnection(connectionstring);
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public static bool PasswordCheck(string email, string wachtwoord)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "PasswordCheck";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_gpassword", wachtwoord);
                    cmd.Parameters.Add("p_email", email);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    return reader.GetInt32(0) == 1;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool InsertUser(Volunteer user)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "InsertUserVol";
                cmd.CommandText = query;
                cmd.Connection = connection;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_email", user.Email);
                    cmd.Parameters.Add("p_fullname", user.Name);
                    cmd.Parameters.Add("p_gpassword", user.Password);
                    cmd.Parameters.Add("p_gpermission", user.Permission);
                    cmd.Parameters.Add("p_dob", user.Dob);
                    cmd.Parameters.Add("p_address", user.Address);
                    cmd.Parameters.Add("p_city", user.City);
                    cmd.Parameters.Add("p_phonenumber", user.PhoneNumber);
                    cmd.Parameters.Add("p_profilepic", user.ProfilePic);
                    cmd.Parameters.Add("p_vog", user.Vog);
                    cmd.Parameters.Add("p_biography", user.Bio);
                    cmd.Parameters.Add("p_driverslicense", user.DriversLicense);
                    cmd.Parameters.Add("p_hascar", user.HasCar);
                    cmd.Parameters.Add("p_publictransport", user.PublicTransport);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool InsertUser(Dependant user)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "InsertUserVol";
                cmd.CommandText = query;
                cmd.Connection = connection;
                try
                {              
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_email", user.Email);
                    cmd.Parameters.Add("p_fullname", user.Name);
                    cmd.Parameters.Add("p_gpassword", user.Password);
                    cmd.Parameters.Add("p_gpermission", user.Permission);
                    cmd.Parameters.Add("p_dob", user.Dob);
                    cmd.Parameters.Add("p_address", user.Address);
                    cmd.Parameters.Add("p_city", user.City);
                    cmd.Parameters.Add("p_phonenumber", user.PhoneNumber);
                    cmd.Parameters.Add("p_profilepic", user.ProfilePic);
                    cmd.Parameters.Add("p_biography", user.Bio);
                    cmd.Parameters.Add("p_publictransport", user.PublicTransport);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool DeleteTopic(Topic topic)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "DeleteTopic";
                cmd.CommandText = query;
                cmd.Connection = connection;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_topicid", topic.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


#endregion

        #region Forum
        public static List<Topic> GetQuestions(string email, bool active = true, bool flag = false)
        {
            List<Topic> topics;

            // als gebruiker gast of vrijwilliger is, haal alle vragen op uit database
            topics = new List<Topic>();

            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetQuestionsFrom";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_email", email);
                    cmd.Parameters.Add("p_active", active);
                    cmd.Parameters.Add("p_flag", flag);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    while (reader.Read())
                    {
                        Topic topic = new Topic(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), Convert.ToBoolean(reader.GetInt32(6)), reader.GetInt32(7), reader.GetDateTime(8), reader.GetDateTime(9), reader.GetDateTime(10), reader.GetDateTime(11), Convert.ToBoolean(reader.GetInt32(12)), Convert.ToBoolean(reader.GetInt32(13)));
                        topics.Add(topic);
                    }
                }//        public Topic(int id, string account, string transport, string header, string body, string location, bool urgency, int travelTime, DateTime dateHelpNeededStart, DateTime dateHelpNeededEnd, DateTime dateposted)
                catch
                {
                    return null;
                }
            }

            return topics;
        }

        public static List<Topic> GetQuestions(bool active = true, bool flag = false)
        {
            List<Topic> topics;

            // als gebruiker gast of vrijwilliger is, haal alle vragen op uit database
            topics = new List<Topic>();

            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetQuestions";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_active", active);
                    cmd.Parameters.Add("p_flag", flag);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Topic topic = new Topic(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), Convert.ToBoolean(reader.GetInt32(6)), reader.GetInt32(7), reader.GetDateTime(8), reader.GetDateTime(9), reader.GetDateTime(10), reader.GetDateTime(11), Convert.ToBoolean(reader.GetInt32(12)), Convert.ToBoolean(reader.GetInt32(13)));
                        topics.Add(topic);
                    }
                }
                catch
                {
                    return null;
                }
            }

            return topics;
        }

        public static bool InsertTopic(Topic topic)
        {
            DateTime date1 = new DateTime(topic.DateHelpNeededStart.Year, topic.DateHelpNeededStart.Month, topic.DateHelpNeededStart.Day, topic.DateHelpNeededStart.Hour, topic.DateHelpNeededStart.Minute, 00);
            DateTime date2 = new DateTime(topic.DateHelpNeededEnd.Year, topic.DateHelpNeededEnd.Month, topic.DateHelpNeededEnd.Day, topic.DateHelpNeededEnd.Hour, topic.DateHelpNeededEnd.Minute, 00);
            using (connection = new OracleConnection(connectionstring))
            {
                int urgencyInt = topic.Urgency ? 1 : 0;
                query = "InsertTopic";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_email", topic.Account);
                    cmd.Parameters.Add("p_topicheader", topic.Header);
                    cmd.Parameters.Add("p_transportname", topic.Transport);
                    cmd.Parameters.Add("p_topicbody", topic.Body);
                    cmd.Parameters.Add("p_topiclocation", topic.Location);
                    cmd.Parameters.Add("p_urgency", urgencyInt);
                    cmd.Parameters.Add("p_traveltime", topic.TravelTime);
                    cmd.Parameters.Add("p_datehelpneededstart", date1);
                    cmd.Parameters.Add("p_datehelpneededend", date2);
                    cmd.Parameters.Add("p_datelastedited", topic.DateLastEdited);
                    cmd.Parameters.Add("p_dateposted", topic.DatePosted);
                    cmd.Parameters.Add("p_active", topic.Active);
                    cmd.Parameters.Add("p_flag", topic.Flag);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static List<Reply> GetReplies(Topic topic)
        {
            List<Reply> replies = new List<Reply>();

            // als gebruiker gast of vrijwilliger is, haal alle vragen op uit database

            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetReplies";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_topicid", topic.Id);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        replies.Add(new Reply(reader.GetInt32(0), reader.GetString(1), topic, reader.GetString(3), reader.GetDateTime(4), reader.GetDateTime(5)));
                    }
                    return replies;
                }
                catch
                {
                    return replies;
                }
            }
        }

        public static bool InsertReply(Reply reply)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "InsertReply";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_email", reply.Email);
                    cmd.Parameters.Add("p_topicid", reply.TopicID);
                    cmd.Parameters.Add("p_replybody", reply.Body);
                    cmd.Parameters.Add("p_dateposted", reply.DatePosted);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static void DeleteReply(Reply reply)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "UpdateReply";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_replyid", reply.Id);
                    cmd.Parameters.Add("p_active", reply.Active);
                    cmd.Parameters.Add("p_flag", reply.Flag);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }
        }

        #endregion

        #region Calender
        public static List<Appointment> GetAllAppointmentsFrom(string email)
        {
            List<Appointment> list = new List<Appointment>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetAllAppointmentsFrom";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_email", email);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Appointment(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), 
                                                reader.GetString(6), reader.GetInt32(7), reader.GetString(9)));
                    }
                    return list;
                }
                catch
                {
                    return null;
                }
            }

        }

        public static bool InsertAppointment(Appointment appointment)
        {
            DateTime dateOne = new DateTime(appointment.DateHelpNeeded1.Year, appointment.DateHelpNeeded1.Month, appointment.DateHelpNeeded1.Day, appointment.DateHelpNeeded1.Hour, appointment.DateHelpNeeded1.Minute, 00);
            using (connection = new OracleConnection(connectionstring))
            {
                query = "InsertAppointment";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_sender", appointment.Sender);
                    cmd.Parameters.Add("p_transportname", appointment.Transport);
                    cmd.Parameters.Add("p_appointmentheader", appointment.Header);
                    cmd.Parameters.Add("p_datehelpneeded", dateOne);
                    cmd.Parameters.Add("p_appointmentlocation", appointment.Location);
                    cmd.Parameters.Add("p_traveltime", appointment.TravelTime);
                    cmd.Parameters.Add("p_receiver", appointment.Receiver);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool DeleteAppointment(Appointment appointment)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "DeleteAppointment";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_appointmentid", appointment.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        #endregion

        #region Profile
        // Get flags
        public static int GetProfileFlags(string email)
        {
            int getFlags = 0;
            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetProfileFlags";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_email", email);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    getFlags = reader.GetInt32(0);
                }
                catch
                {
                    return getFlags;
                }
            }
            return getFlags;
        }

        // Update flags
        public static bool FlagProfile(string email)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "FlagProfile";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_email", email);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool FlagTopic(int topicid)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "FlagTopic";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_topicid", topicid);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool FlagReply(int replyid)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "FlagReply";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_replyid", replyid);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        // profile update
        public static bool UpdateProfile(string phonenumber, string biography, string email, bool driverslicense, bool hascar)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "UpdateProfileVol";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_email", email);
                    cmd.Parameters.Add("p_phonenumber", phonenumber);
                    cmd.Parameters.Add("p_biography", biography);
                    cmd.Parameters.Add("p_driverslicense", Convert.ToInt32(driverslicense));
                    cmd.Parameters.Add("p_hascar", Convert.ToInt32(hascar));
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool UpdateProfile(string phonenumber, string biography, string email)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "UpdateProfileVol";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_email", email);
                    cmd.Parameters.Add("p_phonenumber", phonenumber);
                    cmd.Parameters.Add("p_biography", biography);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        // profilepic update
        public static void UpdateProfilePic(byte[] profilepic, string email)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "UpdateProfilePic";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_email", email); 
                    cmd.Parameters.Add("p_profilepic", profilepic);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        // profileVOG update
        public static void UpdateProfileVog(byte[] vog, string email)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "UpdateProfileVog";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_email", email);
                    cmd.Parameters.Add("p_vog", vog);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
        #endregion

        #region Chat

        public static List<ChatMessage> GetLastMessages(User currentUser, User contact, int lastmessageid)
        {
            List<ChatMessage> messages = new List<ChatMessage>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetLastMessages";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_sender", currentUser.Email);
                    cmd.Parameters.Add("p_receiver", contact.Email);
                    cmd.Parameters.Add("p_lastmessageid", lastmessageid);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(2).ToLower() == currentUser.Email.ToLower())
                        {
                            messages.Add(new ChatMessage(reader.GetInt32(0), reader.GetString(1), currentUser, contact, reader.GetDateTime(4)));
                        }
                        else
                        {
                            messages.Add(new ChatMessage(reader.GetInt32(0), reader.GetString(1), contact, currentUser, reader.GetDateTime(4)));
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
            return messages;
        }

        public static List<string> GetChatOverview(string email)
        {
            List<string> users = new List<string>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetChatOverview";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_email", email);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == email)
                        {
                            users.Add(reader.GetString(1));
                        }
                        else
                        {
                            users.Add(reader.GetString(0));
                        }
                    }
                    return users;
                }
                catch
                {
                    return null;
                }
            }
        }

        //vrijwilliger@email.com
        //hulpbehoevende@email.com

        public static void InsertMessage(ChatMessage message)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "InsertMessage";
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_sender", message.Sender.Email);
                    cmd.Parameters.Add("p_text", message.Text);
                    cmd.Parameters.Add("p_receiver", message.Receiver.Email);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                   
                }
            }
        }

        #endregion

        #region Review

        // Een lijst met reviews van de gebruiker ophalen
        public static List<Review> GetReviews(string email)
        {
            List<Review> reviews = new List<Review>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetReviews";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_email", email);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Review rev = new Review(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt32(4));
                        reviews.Add(rev);
                    }
                    return reviews;
                }
                catch
                {
                    return null;
                }
            }
        }

        // Een review schrijven
        public static bool InsertReview(Review review)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "InsertReview";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_sender", review.Sender);
                    cmd.Parameters.Add("p_receiver", review.Receiver);
                    cmd.Parameters.Add("p_reviewbody", review.Body);
                    cmd.Parameters.Add("p_rating", review.Rating);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion

        #region Admin

        /*
        public static List<User> GetFlaggedUsers(bool flaggedchk, bool activechk)
        {
            List<User> flaggedusers = new List<User>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT email, username, gpassword, gpermission, dob, phonenumber, profilepic, vog, biography, driverslicense, active FROM guser WHERE flag = " + Convert.ToInt32(flaggedchk) + " AND active=" + Convert.ToInt32(activechk);
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bool active = reader.GetInt32(10) == 1;
                        bool driverslicense = reader.GetInt32(9) == 1;
                        int permission = reader.GetInt32(3);
                        switch (permission)
                        {
                            case 1:
                                flaggedusers.Add(new Dependant(reader.GetString(0), reader.GetString(1), reader.GetString(2), permission, active, reader.GetDateTime(4), reader.GetString(5), "", (byte[])reader.GetValue(6)));
                                break;
                            case 2:
                                flaggedusers.Add(new Volunteer(reader.GetString(0), reader.GetString(1), reader.GetString(2), permission, active, reader.GetDateTime(4), reader.GetString(5), (byte[])reader.GetValue(6), (byte[])reader.GetValue(7), driverslicense));
                                break;
                        }
                    }
                    return flaggedusers;
                }
                catch
                {
                    return null;
                }
            }
        }

        
        public static List<Topic> GetFlaggedTopics(bool flaggedchk, bool activechk)
        {
            List<Topic> flaggedtopics = new List<Topic>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = query = "SELECT topicid, email, topicheader, topicbody, topiclocation, urgency, transport, traveltime, datehelpneededstart, datehelpneededend, dateposted  FROM topic WHERE flag = " + Convert.ToInt32(flaggedchk) + " AND active=" + Convert.ToInt32(activechk);
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bool urgent = reader.GetInt32(5) == 1;
                        Topic flaggedtopic = new Topic(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), urgent, reader.GetString(6), reader.GetInt32(7), reader.GetDateTime(8), reader.GetDateTime(9), reader.GetDateTime(10));
                        flaggedtopics.Add(flaggedtopic);
                    }
                    return flaggedtopics;
                }
                catch
                {
                    return null;
                }
            }

        }

        public static List<Reply> GetFlaggedReplies(bool flaggedchk, bool activechk)
        {
            List<Reply> flaggedreplies = new List<Reply>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT replyid, email, topicid, replybody, dateposted FROM reply WHERE flag = " + Convert.ToInt32(flaggedchk) + " AND active=" + Convert.ToInt32(activechk);
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Reply flaggedreply = new Reply(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetDateTime(4));
                        flaggedreplies.Add(flaggedreply);
                    }
                    return flaggedreplies;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<Review> GetFlaggedReviews(bool flaggedchk, bool activechk)
        {
            List<Review> flaggedreviews = new List<Review>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT reviewid, receiver, reviewbody, dateposted, rating FROM review WHERE flag = " + Convert.ToInt32(flaggedchk) + " AND active=" + Convert.ToInt32(activechk);
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Review flaggedreview = new Review(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(4), reader.GetDateTime(3));
                        flaggedreviews.Add(flaggedreview);
                    }
                    return flaggedreviews;
                }
                catch
                {
                    return null;
                }
            }
        }
        */

        public static bool UnactivateProfile(User user, bool activateOrDisable)
        {
            bool active = activateOrDisable;
            bool flag = !activateOrDisable;
            using (connection = new OracleConnection(connectionstring))
            {
                query = "UPDATE guser SET active = " + Convert.ToInt32(active) + ", flag = " + Convert.ToInt32(flag) + " WHERE email=:pemail";
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("email", user.Email);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool UnactivateTopic(Topic topic, bool activateOrDisable)
        {
            bool active = activateOrDisable;
            bool flag = !activateOrDisable;
            using (connection = new OracleConnection(connectionstring))
            {
                query = "UPDATE topic SET active = " + Convert.ToInt32(active) + ", flag = " + Convert.ToInt32(flag) + " WHERE topicid=:ptopicid";
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("topicid", topic.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }

        public static bool UnactivateReply(Reply reply, bool activateOrDisable)
        {
            bool active = activateOrDisable;
            bool flag = !activateOrDisable;
            using (connection = new OracleConnection(connectionstring))
            {
                query = "UPDATE reply SET active = " + Convert.ToInt32(active) + ", flag = " + Convert.ToInt32(flag) + " WHERE replyid=:preplyid";
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("replyid", reply.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }

        public static bool UnactivateReview(Review review, bool activateOrDisable)
        {
            bool active = activateOrDisable;
            bool flag = !activateOrDisable;
            using (connection = new OracleConnection(connectionstring))
            {
                query = "UPDATE guser SET active = " + Convert.ToInt32(active) + ", flag = " + Convert.ToInt32(flag) + " WHERE reviewid=:previewid";
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("reviewid", review.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
        #endregion
        /*
        public static User GetUser(string email)
        {
            User userToReturn;
            permission = GetPermissionLevel(email);
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT email, username, gpassword, gpermission, dob, phonenumber, profilepic, vog, biography, driverslicense, active FROM guser WHERE email = :pemail AND active = 1";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("email", email);
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    bool active = (reader.GetInt32(10) == 1);
                    if (permission == 0)
                    {
                        userToReturn = new Administrator(reader.GetString(0), reader.GetString(1), reader.GetInt32(3));
                    }
                    else if (permission == 1)
                    {
                        byte[] profilepic;
                        if (((byte[])reader.GetValue(6)).Length == 0)
                        {
                            profilepic = Blob.BitmapToBLOB(Resources.default_pp);
                        }

                        else
                        {
                            profilepic = (byte[])reader.GetValue(6);
                        }

                        userToReturn = new Dependant(reader.GetString(0), reader.GetString(1), reader.GetString(2), permission, active, reader.GetDateTime(4), reader.GetString(5), reader.GetValue(8).ToString(), profilepic);
                    }
                    else if (permission == 2)
                    {
                        bool driverslicense = (reader.GetInt32(9) == 1);
                        userToReturn = new Volunteer(reader.GetString(0), reader.GetString(1), reader.GetString(2), permission, active, reader.GetDateTime(4), reader.GetString(5), (byte[])reader.GetValue(6), (byte[])reader.GetValue(7), reader.GetValue(8).ToString(), driverslicense);
                    }
                    else
                    {
                        return null;
                    }
                    return userToReturn;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        */



        public static int GetPermissionLevel(string email)
        {
            permission = 3;
            using (connection = new OracleConnection(connectionstring))
            {
                query = "GetPermissionLevel";
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("Return_Value", OracleDbType.RefCursor, ParameterDirection.ReturnValue));
                    cmd.Parameters.Add("p_email", email);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                        permission = reader.GetInt32(0);
                    return permission;
                }
                catch
                {
                    return permission;
                }
            }

        }

        //public static User NameGetter(string email)
        //{
        //    using (connection = new OracleConnection(connectionstring))
        //    {
        //        query = "SELECT username, permission FROM guser WHERE email = :pemail AND active = 1";
        //        cmd.CommandText = query;
        //        cmd.Connection = connection;
        //        try
        //        {
        //            connection.Open();
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.Add("email", email);
        //            reader = cmd.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                return new User(reader.GetString(0), email);
        //            }

        //            return null;
        //        }
        //        catch 
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
