using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Hospital_Management_MVC.Models
{
    public class DbConnection
    {
        SqlConnection con = new SqlConnection(@"server=MSI\SQLEXPRESS;database=HospitalManagement;integrated security=true;");

        public string createUser(userRegister userobject)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Userregister", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", userobject.Email);
                cmd.Parameters.AddWithValue("@username", userobject.Username);
                cmd.Parameters.AddWithValue("@password", userobject.Password);
                cmd.Parameters.AddWithValue("@role", userobject.User_Role);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "User Inserted Successfully";
            }
            catch (Exception ex)
            {
                return "User Insertion Failed : " + ex.Message;
            }

        }
        public string RegisterDocter(DocterRegister docterobject)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Docterregister", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", docterobject.Userid);
                cmd.Parameters.AddWithValue("@name", docterobject.Name);
                cmd.Parameters.AddWithValue("@experience", docterobject.Experience);
                cmd.Parameters.AddWithValue("@availability", docterobject.Availability);
                cmd.Parameters.AddWithValue("@specialization", docterobject.Specialization);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Doceter Successfully Registered";
            }
            catch (Exception ex)
            {
                return "Docter registration failed" + ex.Message;
            }

        }
        public string RegisterPatient(PatientRegister patientobject)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("patientregister", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", patientobject.Userid);
                cmd.Parameters.AddWithValue("@name", patientobject.Name);
                cmd.Parameters.AddWithValue("@age", patientobject.Age);
                cmd.Parameters.AddWithValue("@dob", patientobject.DOB);
                cmd.Parameters.AddWithValue("@gender", patientobject.Gender);
                cmd.Parameters.AddWithValue("@medicalhistory", patientobject.Medicalhistory);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Patient Successfully registered";
            }
            catch (Exception ex)
            {
                return "Patient registration failed: " + ex.Message;
            }
        }
        public int logincheck(string uname, string password)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("logincout", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", uname);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Login check failed: " + ex.Message);
            }
        }
        public userRetrieveDTO Getuserinfo(string uname, string pswd)
        {
            userRetrieveDTO users = null;
            SqlCommand cmd = new SqlCommand("getuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", uname);
            cmd.Parameters.AddWithValue("@password", pswd);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                users = new userRetrieveDTO
                {
                    Userid = Convert.ToInt32(dr["Userid"]),
                    Email = dr["Email"].ToString(),
                    Role = dr["User_role"].ToString()
                };
                con.Close();
                return users;
            }
            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (new Exception("Invalid user went wrong"));
            }


        }
        public DoctorRetrieveDTO GetDoctor(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("getdoctor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                DoctorRetrieveDTO docter = null;

                if (dr.Read())
                {
                    docter = new DoctorRetrieveDTO
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Userid = Convert.ToInt32(dr["Userid"]),
                        Name = dr["Name"].ToString(),
                        Experience = dr["Experience"].ToString(),
                        Availability = dr["Availability"].ToString(),
                        Specialization = dr["Specialization"].ToString()
                    };
                    con.Close();
                    return docter;
                }
                else
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    return docter;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving doctor information: " + ex.Message);
            }
        }
        public DoctorbyidDTO GetDoctorById(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("getdoctorbyid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                DoctorbyidDTO docter = null;

                if (dr.Read())
                {
                    docter = new DoctorbyidDTO
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Userid = Convert.ToInt32(dr["Userid"]),
                        Name = dr["Name"].ToString(),
                        Experience = dr["Experience"].ToString(),
                        Availability = dr["Availability"].ToString(),
                        Specialization = dr["Specialization"].ToString()
                    };
                    con.Close();
                    return docter;
                }
                else
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    return docter;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving doctor information: " + ex.Message);
            }
        }
        public AdminRetriveDTO GetAdmin(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("getadmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dto = cmd.ExecuteReader();

                AdminRetriveDTO details = null;

                if (dto.Read())
                {
                    details = new AdminRetriveDTO
                    {
                        Userid = Convert.ToInt32(dto["Userid"]),
                        Name = dto["Name"].ToString(),
                        Age = Convert.ToInt32(dto["Age"])
                    };
                    con.Close();
                    return details;
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving admin information: " + ex.Message);
            }
        }

        public string AddAppointment(addAppointment obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("addappointment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("patientid", obj.PatientId);
                cmd.Parameters.AddWithValue("doctorid", obj.DoctorId);
                cmd.Parameters.AddWithValue("date", obj.Date);
                cmd.Parameters.AddWithValue("time", obj.TimeSlot);
                cmd.Parameters.AddWithValue("status", obj.Status);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i == 1)
                {
                    return "Added successfully";
                }
                else
                {
                    return "Failed to book appointment";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<DoctorRetrieveDTO> GetAllDoctors()
        {
            try
            {
                List<DoctorRetrieveDTO> doctors = new List<DoctorRetrieveDTO>();
                SqlCommand cmd = new SqlCommand("getalldoctors", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    doctors.Add(new DoctorRetrieveDTO()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Userid = Convert.ToInt32(dr["Userid"]),
                        Name = dr["Name"].ToString(),
                        Experience = dr["Experience"].ToString(),
                        Availability = dr["Availability"].ToString(),
                        Specialization = dr["Specialization"].ToString()

                    });

                }
                con.Close();
                return doctors;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<PatientRetreiveDTO> GetAllPatients()
        {
            try
            {
                List<PatientRetreiveDTO> patients = new List<PatientRetreiveDTO>();
                SqlCommand cmd = new SqlCommand("getallpatients", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    patients.Add(new PatientRetreiveDTO()
                    {
                        id = Convert.ToInt32(dr["Id"]),
                        Userid = Convert.ToInt32(dr["Userid"]),
                        Name = dr["Name"].ToString(),
                        Age = Convert.ToInt32(dr["Age"]),
                        Gender = dr["Gender"].ToString(),
                        Medicalhistory = dr["Medicalhistory"].ToString()

                    });

                }
                con.Close();
                return patients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<string> GetBookedSlots(int doctorid, DateTime date)
        {
            SqlCommand cmd = new SqlCommand("getbookedslots", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", doctorid);
            cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> bookedSlots = new List<string>();

            while (dr.Read())
            {
                bookedSlots.Add(dr["TimeSlot"].ToString());
            }
            con.Close();
            return bookedSlots;
        }
        public string UpdateDoctor(DoctorbyidDTO docter)
        {
            SqlCommand cmd = new SqlCommand("updatedoctor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", docter.Id);
            cmd.Parameters.AddWithValue("@name", docter.Name);
            cmd.Parameters.AddWithValue("@experience", docter.Experience);
            cmd.Parameters.AddWithValue("@availability", docter.Availability);
            cmd.Parameters.AddWithValue("@specialization", docter.Specialization);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                return "successfully updated";
            }
            else
            {
                return "Updation failed";
            }

        }
        public string DeleteDoctor(int id)
        {
            try
            {
                SqlCommand cm = new SqlCommand("checkappointment", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@id", id);
                con.Open();
                int i = cm.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    SqlCommand cm1 = new SqlCommand("deleteappointmentdocter", con);
                    cm1.CommandType = CommandType.StoredProcedure;
                    cm1.Parameters.AddWithValue("@doctorid", id);
                    con.Open();
                    cm1.ExecuteNonQuery();
                    con.Close();
                }


                SqlCommand cmd = new SqlCommand("deleteuser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int j = cmd.ExecuteNonQuery();
                con.Close();
                if (j == 1)
                {
                    return "Doctor deleted successfully";
                }
                else
                {
                    return "Doctor deletion failed";
                }
            }
            catch (Exception ex)
            {
                return "Error deleting doctor: " + ex.Message;
            }
        }
        public List<AppointmentDTO> GetAllAppointments()
        {
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();

            SqlCommand cmd = new SqlCommand("getallappointments", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                AppointmentDTO dto = new AppointmentDTO
                {
                    AppointmentId = Convert.ToInt32(dr["AppointmentId"]),
                    PatientName = dr["PatientName"].ToString(),
                    DoctorName = dr["DoctorName"].ToString(),
                    Date = Convert.ToDateTime(dr["BookDate"]),
                    Timeslot = dr["TimeSlot"].ToString(),
                    Status = dr["Status"].ToString()
                };
                appointments.Add(dto);

            }
            con.Close();
            return appointments;

        }
        public string deleteappointment(int id)
        {
            SqlCommand cmd = new SqlCommand("deleteappointment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i>0)
            {
                return "Successfully Deleted";
                
            }
            return "deletion Failed";


        }
        public string UpdateAppointmentStatus(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("updateappointmentstatusadmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    return "Status updated successfully";
                }
                else
                {
                    return "Status update failed";
                }
            }
            catch (Exception ex)
            {
                return "Error updating status: " + ex.Message;
            }
        }
    }
}
