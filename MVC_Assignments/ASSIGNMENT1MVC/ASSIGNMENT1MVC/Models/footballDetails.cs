using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ASSIGNMENT1MVC.Models
{
    public class footballDetails
    {
        public List<FootballLeague> teamplayedbyjapan()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["footballContext"].ConnectionString))
            {
                List<FootballLeague> japanmatchlist = new List<FootballLeague>();
                SqlCommand cmd = new SqlCommand("select * from FootBallLeague where TeamName1 ='Japan' OR  TeamName2 ='Japan'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    japanmatchlist.Add(
                        new FootballLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            TeamName1 = Convert.ToString(dr["TeamName1"]),
                            TeamName2 = Convert.ToString(dr["TeamName2"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                            Status1 = Convert.ToString(dr["Status1"]),
                            Points = Convert.ToInt32(dr["Points"])
                        });

                }
                return japanmatchlist;

            }
        }

        public List<FootballLeague> WinningMatchDetails()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["footballContext"].ConnectionString))
            {
                List<FootballLeague> winninglist = new List<FootballLeague>();
                SqlCommand cmd = new SqlCommand("select * from FootBallLeague where Status1 = 'Win'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    winninglist.Add(
                        new FootballLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            TeamName1 = Convert.ToString(dr["TeamName1"]),
                            TeamName2 = Convert.ToString(dr["TeamName2"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                            Status1 = Convert.ToString(dr["Status1"]),
                            Points = Convert.ToInt32(dr["Points"])
                        });

                }
                return winninglist;

            }
        }


        public List<FootballLeague> GetMatchdetails()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["footballContext"].ConnectionString))
            {
                List<FootballLeague> MatchDetails = new List<FootballLeague>();
                SqlCommand cmd = new SqlCommand("select * from FootBallLeague", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    MatchDetails.Add(
                        new FootballLeague
                        {
                            MatchID = Convert.ToInt32(dr["MatchID"]),
                            TeamName1 = Convert.ToString(dr["TeamName1"]),
                            TeamName2 = Convert.ToString(dr["TeamName2"]),
                            WinningTeam = Convert.ToString(dr["WinningTeam"]),
                            Status1 = Convert.ToString(dr["Status1"]),
                            Points = Convert.ToInt32(dr["Points"])
                        });

                }
                return MatchDetails;

            }
        }

        public bool AddMatchResult(FootballLeague Match)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["footballContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Insertdata", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@MatchID", Match.MatchID);
                cmd.Parameters.AddWithValue("@TeamName1", Match.TeamName1);
                cmd.Parameters.AddWithValue("@TeamName2", Match.TeamName2);
                cmd.Parameters.AddWithValue("@Status1", Match.Status1);
                cmd.Parameters.AddWithValue("@WinningTeam", Match.WinningTeam);
                cmd.Parameters.AddWithValue("@Points", Match.Points);

                con.Open();
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                    return true;
                else
                    return false;
            }

        }
    }
}