using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Sockets;
using System.Diagnostics;

namespace ITC
{
    public partial class Form1 : Form
    {
        string path = Application.StartupPath;
        string[] linea1;
        string[] linea2;
        string[] linea3;
        string[] linea4;
        string[] linea5;
        string[] linea6;
        string[] linea7;
        string[] linea8;
        string[] linea9;

        string[] linea10;
        string[] linea11;
        string[] linea12;

        string ipok;
        string puertook;
        string idok;

        string ipbd;
        string nombd;
        string usubd;
        string passbd;
        string hostmail;
        string puertoemail;
        string email;
        string emailusuario;
        string passemail;
        string pathjava;
        int relojiduser;
        string ipreloj;
        string nomimpresora;
        string modalidad;
        Int64 ultmarca;
        string bdmaxdatetime;
        string bdmaxdatetime1;
        string bdmaxdatetime3;
        string bdmaxdatetime4;
        string bdip;
        string bdpuerto;
        string bdmachine;
        string bdmachinealias;
        string connip;
        string connpuerto;
        string connmachine;
        bool bIsConnected = false;
        string enviohuellainvalida;
        string ipusuario;
        string bdnomimpresora;
        string bdmodo;
        string bdrelojasociado;
        string bdname;
        string consultauserid;
        string impresoraasociada;
        string puertoimpresoraasociada;

        string impnombre;
        string impdpto;
        string impssn;
        string imprut;
        string impdireccion;
        string impcomuna;
        string impregion;

        int rano;
        Int64 ultm_reg;
        int rmes;
        int rdia;
        int rhora;
        int rminuto;
        int rsegundo;
        //REVISAR
        string rano2;
        string rmes2;
        string rdia2;
        string rhora2;
        string rminuto2;
        string rsegundo2;
        //
        int rstate;
        string rbadgenumber;
        string rssn;
        int ruserid;
        string sstate;
        int riVerifyMethod;
        string sVerifyMethod;
        string checksumoupput;
        string estadomarca;
        string rutFormateado;
        int yaprocesado;
        int icuentarelojes;
        int duplicados;
        int idservicios1;
        string serv_ulti_upd;

        string bodyemail;

        string msg1;
        string msg2;
        string msg3;
        string msg4;
        string msg5;
        string msg6;
        string msg7;
        string msg8;
        string msg9;
        string msg10;
        string msg11;
        string msg12;
        string msg13;
        string msg14;
        string msg15;
        string msg16;
        string msg17;
        string msg18;
        string msg19;
        string msg20;
        string msg21;
        string msg22;
        string msg23;
        string msg24;
        string msg25;
        string numeroticketxhoy;
        string numeroticketxserv;
        Int64 formatoult_reg;

        int USERIDxx;
        DateTime CHECKTIME;
        string BADGENUMBER;
        string SSN;
        string name;
        string CHECKTYPE;
        string checksumxx;
        int VERIFYCODE;
        string IP;
        string sn;

        string rutsindatos = "No existe Rut";
        string empresasindatos = "No existe Empresa";
        string nombresindatos = "No existe Nombre";

        List<string> relojesonline;

        string[] bdmaxdatetime2;
        string formatohora;
        string fechasinformato;

        string f2vfipbdsoft;
        string f2vfbdsoft;
        string f2vfusersoft;
        string f2vfclavesoft;
        int f2check;

        int datiduser;
        string datfecha;
        int datservicio;
        string datsn;

        int valdia;
        string diaini;
        string diafin;

        int turnoid;
        string turnoname;
        string turnostart;
        string turnoend;
        string[] turnostart1;
        string[] turnoend1;
        string turnostart2;
        string turnoend2;

        int controlconn;

        Socket clientSocket;
        Socket clientSocket2;
        System.Data.SqlClient.SqlConnection conn;
        System.Data.SqlClient.SqlConnection conn2;
        System.Data.SqlClient.SqlConnection conn3;

        //Códigos impresora POS
        private static byte[] commandCutPaper = new byte[] { 0x1B, 0x69 };
        private static byte[] CarriageReturn = new byte[] { 0x0d, 0x0a };

        private static byte[] setfont2double = new byte[] { 0x1B, (byte)'!', 0x38 };
        private static byte[] setfont2normal = new byte[] { 0x1B, (byte)'!', 0x00 };
        private static byte[] setfont2medio = new byte[] { 0x1B, (byte)'!', 0x16 };

        private static byte[] cancelprint = new byte[] { 0x1B, 0x18 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TEST
            //long ttt;
            //ttt = Convert.ToInt64(235900);

            //TEST
            generaversion();
            cargadatosbd();
            conectarbd();
            timer1.Enabled = true;
        }

        private void generaversion()
        {
            DateTime dt = DateTime.Now;
            log(dt + ": Versión 1.0.4");
        }

        private void cargadatosbd()
        {
            using (StreamReader Lee = new StreamReader(path + @"\casino.out"))
            {
                string Linea;
                Linea = Lee.ReadLine();
                f2check = Convert.ToInt32(Linea);

                Linea = Lee.ReadLine();
                f2vfipbdsoft = Linea;

                Linea = Lee.ReadLine();
                f2vfbdsoft = Linea;

                Linea = Lee.ReadLine();
                f2vfusersoft = Linea;

                Linea = Lee.ReadLine();
                f2vfclavesoft = Linea;


            }
        }

        private void conectarbd()
        {

            if (f2check == 0)
            {
                try
                {
                    conn = new System.Data.SqlClient.SqlConnection();
                    conn.ConnectionString = "Server=" + f2vfipbdsoft + ";initial catalog=" + f2vfbdsoft + ";user=" + f2vfusersoft + ";password=" + f2vfclavesoft + ";Trusted_Connection=FALSE";
                    conn.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo establecer conexión con la base de datos");
                    this.Close();
                    DateTime dtex = DateTime.Now;
                    string bderror = dtex + ": PRC-conectarbd - " + ex.Message;
                    log(bderror);
                }
            }
        }

        private void conectarbd2()
        {

            if (f2check == 0)
            {
                try
                {
                    conn2 = new System.Data.SqlClient.SqlConnection();
                    conn2.ConnectionString = "Server=" + f2vfipbdsoft + ";initial catalog=" + f2vfbdsoft + ";user=" + f2vfusersoft + ";password=" + f2vfclavesoft + ";Trusted_Connection=FALSE";
                    conn2.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo establecer conexión con la base de datos");
                    this.Close();
                    DateTime dtex = DateTime.Now;
                    string bderror = dtex + ": PRC-conectarbd - " + ex.Message;
                    log(bderror);
                }
            }
        }

        private void conectarbd3()
        {

            if (f2check == 0)
            {
                try
                {
                    conn3 = new System.Data.SqlClient.SqlConnection();
                    conn3.ConnectionString = "Server=" + f2vfipbdsoft + ";initial catalog=" + f2vfbdsoft + ";user=" + f2vfusersoft + ";password=" + f2vfclavesoft + ";Trusted_Connection=FALSE";
                    conn3.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo establecer conexión con la base de datos");
                    this.Close();
                    DateTime dtex = DateTime.Now;
                    string bderror = dtex + ": PRC-conectarbd - " + ex.Message;
                    log(bderror);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //conectarbd();

                String ultimoreg = "select distinct CONVERT(varchar(100),max(fecha),112), CONVERT(TIME(0),max(fecha)), CONVERT(varchar(100),max(fecha),120), CONVERT(varchar(100),max(fecha),110), MAX(ultm_reg) from casino where sn not in ('MANUAL') and ultm_reg = (SELECT MAX(ultm_reg) from casino where sn not in ('MANUAL'))";
                SqlCommand cmdultimoreg = new SqlCommand(ultimoreg, conn);
                SqlDataReader readerultimoreg = cmdultimoreg.ExecuteReader();

                //MessageBox.Show("intenta entrar");

                if (readerultimoreg.HasRows)
                {
                    readerultimoreg.Read();

                    bdmaxdatetime = Convert.ToString(readerultimoreg[0]);
                    bdmaxdatetime1 = Convert.ToString(readerultimoreg[1]);
                    bdmaxdatetime3 = Convert.ToString(readerultimoreg[2]);
                    bdmaxdatetime4 = Convert.ToString(readerultimoreg[3]);
                    bdmaxdatetime2 = bdmaxdatetime1.Split(':');
                    formatohora = String.Concat(bdmaxdatetime2[0], bdmaxdatetime2[1], bdmaxdatetime2[2]);
                    fechasinformato = bdmaxdatetime + formatohora;
                    formatoult_reg = Convert.ToInt64(readerultimoreg[4]);
                    serv_ulti_upd = formatoult_reg.ToString();
                    //MessageBox.Show(ultmarca + "Antes de cambiar en 0");
                    if (ultmarca == 0)
                    {
                        ultmarca = Convert.ToInt64(fechasinformato);
                        ultm_reg = Convert.ToInt64(readerultimoreg[4]);
                       // MessageBox.Show(ultmarca + "Ultima marca "+ ultm_reg+  "ulm reg" + formatoult_reg + " vs ulm reg ");
                    }

                }
                else
                {
                    DateTime dtcarga = DateTime.Now;
                    log(dtcarga + ": No existen marcas en Casino");
                }

                //if (Convert.ToInt64(fechasinformato) > ultmarca)
                if (formatoult_reg > ultm_reg )
                {
                    //MessageBox.Show("entra a fecha mayor a marca " + fechasinformato +"  " + ultmarca);
                    timer1.Enabled = false;

                    conn.Close();
                    //MessageBox.Show(ultmarca + "Ultima marca " + ultm_reg + "ulm reg" + formatoult_reg + " vs ulm reg  segunda vez");
                    obtienedatosaprocesar();
                    validadiaconsulta();
                    validaturnosvalidos();

                    ultmarca = Convert.ToInt64(fechasinformato);
                    ultm_reg = formatoult_reg;
                    //MessageBox.Show(ultmarca + "Ultima marca " + ultm_reg + "ulm reg" + formatoult_reg + " vs ulm reg ");

                    controlconn = 1;
                }

                if (controlconn == 0)
                {
                    timer1.Enabled = true;
                    readerultimoreg.Close();
                }
                else
                {
                    conectarbd();
                    controlconn = 0;
                }
            }
            catch (Exception exm2)
            {
                DateTime dtex2 = DateTime.Now;
                string bderror2 = dtex2 + ": PRC-timer1_Tick - " + exm2.Message;
                log(bderror2);
                conn.Close();

                conectarbd();

                timer1.Enabled = false;
                timer1.Enabled = true;
            }
        }

        private void obtienedatosaprocesar()
        {
            try
            {
                conectarbd();

                //String datultimoreg = "select iduser, fecha, servicio, sn from casino where CONVERT(varchar(100),fecha,120) = '" + bdmaxdatetime3 + "'";
                String datultimoreg = "select iduser, fecha, sn from casino where CONVERT(varchar(100),fecha,120) = '" + bdmaxdatetime3 + "'";
                SqlCommand cmddatultimoreg = new SqlCommand(datultimoreg, conn);
                SqlDataReader readerdatultimoreg = cmddatultimoreg.ExecuteReader();
                //MessageBox.Show(ultmarca + "Ultima marca intenta conectar al encontrar algo en la base de datos " + bdmaxdatetime3);
                if (readerdatultimoreg.HasRows)
                {
                    readerdatultimoreg.Read();

                    datiduser = Convert.ToInt32(readerdatultimoreg[0]);
                    datfecha = Convert.ToString(readerdatultimoreg[1]);
                    //datservicio = Convert.ToInt32(readerdatultimoreg[2]);
                    datsn = Convert.ToString(readerdatultimoreg[2]);
                   //MessageBox.Show("encontro algo " + datfecha + " " + datiduser + " " + datsn);
                    conn.Close();
                }
                else
                {
                    DateTime dtcarga = DateTime.Now;
                    log(dtcarga + ": No existen marcas datos");
                    conn.Close();
                }
            }
            catch (Exception exm2)
            {
                DateTime dtex2 = DateTime.Now;
                string bderror2 = dtex2 + ": PRC-obtienedatosaprocesar - " + exm2.Message;
                log(bderror2);
                conn.Close();

                conectarbd();

                timer1.Enabled = false;
                timer1.Enabled = true;
            }
        }

        private void validadiaconsulta()
        {
            try
            {
                conectarbd();

                String dia = "select DATEPART(dw, (CONVERT(varchar(100),'" + bdmaxdatetime3 + "',112)))";
                SqlCommand cmddia = new SqlCommand(dia, conn);
                SqlDataReader readerdia = cmddia.ExecuteReader();

                if (readerdia.HasRows)
                {
                    readerdia.Read();

                    valdia = Convert.ToInt32(readerdia[0]);
                    //MessageBox.Show("encontro el dia  " + valdia);
                    conn.Close();
                }
                else
                {
                    DateTime dtcarga = DateTime.Now;
                    log(dtcarga + ": No se pudo establecer dia de consulta");
                    conn.Close();
                }

                if (valdia == 1)
                {
                    diaini = "MonStart";
                    diafin = "MonEnd";
                }
                if (valdia == 2)
                {
                    diaini = "TuesStart";
                    diafin = "TuesEnd";
                }
                if (valdia == 3)
                {
                    diaini = "WedStart";
                    diafin = "WedEnd";
                }
                if (valdia == 4)
                {
                    diaini = "ThursStart";
                    diafin = "ThursEnd";
                }
                if (valdia == 5)
                {
                    diaini = "FriStart";
                    diafin = "FriEnd";
                }
                if (valdia == 6)
                {
                    diaini = "SatStart";
                    diafin = "SatEnd";
                }
                if (valdia == 7)
                {
                    diaini = "SunStart";
                    diafin = "SunEnd";
                }

            }
            catch (Exception exm2)
            {
                DateTime dtex2 = DateTime.Now;
                string bderror2 = dtex2 + ": PRC-validadiaconsulta -" + exm2.Message;
                log(bderror2);
                conn.Close();

                conectarbd();

                timer1.Enabled = false;
                timer1.Enabled = true;
            }
        }

        private void validaturnosvalidos()
        {
            try
            {
                //timer1.Enabled = false;
                conectarbd();
                String addidserv = "select az.TimeZoneID, CONVERT(TIME(0),az." + diaini + "), CONVERT(TIME(0),az."+ diafin +"), cs.ultm_reg from casino cs, ACTimeZones az where cs.ultm_reg = (SELECT MAX(ultm_reg) from casino) and cs.sn not in ('MANUAL')";
                SqlCommand cmdaddidserv = new SqlCommand(addidserv, conn);
                SqlDataReader readaddidserv = cmdaddidserv.ExecuteReader();

                if (readaddidserv.HasRows)
                {
                   // MessageBox.Show("Realizo la consulta del servicio");
                    while (readaddidserv.Read())
                    {
                       // MessageBox.Show("loco 1");
                        string horaentradacon = Convert.ToString(readaddidserv[1]);
                        string horasalidacon = Convert.ToString(readaddidserv[2]);
                        string otracosa = bdmaxdatetime1;
                       // MessageBox.Show("loco 2");
                       DateTime horademarca = DateTime.ParseExact(otracosa, "HH:mm:ss",CultureInfo.InvariantCulture);
                        DateTime horadementserv = DateTime.ParseExact(horaentradacon, "HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime horadesaliserv = DateTime.ParseExact(horasalidacon, "HH:mm:ss", CultureInfo.InvariantCulture);
                       // MessageBox.Show("loco 3");
                         MessageBox.Show("hora entr5ada "+ horadementserv + " hora salida "+ horadesaliserv + " hora de marca " + horademarca);
                        if (horademarca >= horadementserv && horademarca <= horadesaliserv)
                        {
                           // MessageBox.Show("actualizado el id del servicio");
                            string newidserv = Convert.ToString(readaddidserv[0]);
                            string ultmimo_reg = Convert.ToString(readaddidserv[3]);
                            serv_ulti_upd = ultmimo_reg;
                            conectarbd2();
                            String updateserv = "UPDATE casino SET servicio = " + newidserv + " WHERE ultm_reg = " + ultmimo_reg;
                            SqlCommand cmdudps = new SqlCommand(updateserv, conn2);
                            cmdudps.ExecuteNonQuery();
                            conn2.Close();
                        }
                    }
                }
                conn.Close();
                //timer1.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }



            try
            {
                conectarbd();

                String turnos = "select distinct act.name, act.TimeZoneID, CONVERT(TIME(0)," + diaini + "), CONVERT(TIME(0)," + diafin + "), cs.idservicio " +
                               " from casino_servicioasig cs, " +
                               "      ACTimeZones act " +
                               " where cs.iduser = " + datiduser +
                               " and cs.idservicio = act.TimeZoneID";

                SqlCommand cmdturnos = new SqlCommand(turnos, conn);
                SqlDataReader readercmdturnos = cmdturnos.ExecuteReader();

                if (readercmdturnos.HasRows)
                {
                    //MessageBox.Show("encontro los servicios asiganados de la persona al dia " + diaini);
                    while (readercmdturnos.Read())
                    {
                        //formatohora -> Fecha obtenida registro nuevo
                        turnoname = Convert.ToString(readercmdturnos[0]);
                        turnoid = Convert.ToInt32(readercmdturnos[1]);
                        turnostart = Convert.ToString(readercmdturnos[2]);
                        turnoend = Convert.ToString(readercmdturnos[3]);
                        idservicios1 = Convert.ToInt32(readercmdturnos[4]);
                       // MessageBox.Show("numero de servicio" + idservicios1);
                        turnostart1 = turnostart.Split(':');
                        turnostart2 = String.Concat(turnostart1[0], turnostart1[1], turnostart1[2]);

                        turnoend1 = turnoend.Split(':');
                        turnoend2 = String.Concat(turnoend1[0], turnoend1[1], turnoend1[2]);

                        if (Convert.ToInt32(turnostart2) <= Convert.ToInt32(formatohora) && Convert.ToInt32(turnoend2) >= Convert.ToInt32(formatohora))
                        {
                          //  MessageBox.Show("entro al if ");
                            conectarbd2();
                            try
                            {
                           //     MessageBox.Show(" Busqueda antes de consultar numeros de ticket hoy Id de usuario "+ datiduser + " fecha de busqueda " + bdmaxdatetime + " id del servicio " + idservicios1);
                                String cont_tick_serv = "select count(*) from casino , casino_valexusuarios csval where casino.iduser = csval.iduser " +
                                "and casino.servicio = csval.idserv and Casino.iduser = " + datiduser + " " +
                                "and  CONVERT(varchar(100),(casino.fecha),112) = '" + bdmaxdatetime + "' and csval.idserv = " + idservicios1;

                                SqlCommand cmdcont_tick_serv = new SqlCommand(cont_tick_serv, conn2);
                                SqlDataReader readercmdcont_tick_serv = cmdcont_tick_serv.ExecuteReader();

                                if (readercmdcont_tick_serv.HasRows)
                                {
                                    readercmdcont_tick_serv.Read();
                                  //  MessageBox.Show("entro al contaodr de vales");
                                    string cant_serv_hoy = Convert.ToString(readercmdcont_tick_serv[0]);
                                    Int32 numercomxhoy;
                                    Int32.TryParse(cant_serv_hoy, out numercomxhoy);
                                    conectarbd3();
                                    try
                                    {
                                        String cont_tick_xdia = "select cv.numvales  from casino_valexusuarios cv where idserv = " + idservicios1 + " and iduser = " + datiduser;
                                        SqlCommand cmdcont_tick_xdia = new SqlCommand(cont_tick_xdia, conn3);
                                        SqlDataReader readercmdcont_tick_xdia = cmdcont_tick_xdia.ExecuteReader();
                                        if (readercmdcont_tick_xdia.HasRows)
                                        {
                                            readercmdcont_tick_xdia.Read();
                                         //   MessageBox.Show("entro al contaodr de numero");
                                            string cant_serv_xdia = Convert.ToString(readercmdcont_tick_xdia[0]);
                                            Int32 numercomxdia;
                                            Int32.TryParse(cant_serv_xdia, out numercomxdia);

                                           // MessageBox.Show("Numeros a comparar xhoy "+ numercomxhoy + " xdia "+ numercomxdia);

                                            if (numercomxhoy > numercomxdia)
                                            {
                                             //   MessageBox.Show("El usuario supero el numero de Vales Diarios");
                                                conn.Close();
                                                conn2.Close();
                                                conn3.Close();
                                                conectarbd2();
                                                String updateserv = "UPDATE casino SET servicio = " + -1 + " WHERE ultm_reg = " + serv_ulti_upd;
                                                SqlCommand cmdudps = new SqlCommand(updateserv, conn2);
                                                cmdudps.ExecuteNonQuery();
                                                conn2.Close();
                                                timer1.Enabled = false;
                                                timer1.Enabled = true;
                                            }
                                            else
                                            {
                                                numeroticketxhoy = numercomxhoy.ToString();
                                                numeroticketxserv = numercomxdia.ToString();
                                                //armar mensaje e imprimir
                                               // MessageBox.Show("Manda a imprimir");
                                                conn.Close();
                                                armamensaje();
                                                consultarrelojimpresora();
                                                imprime();
                                            }
                                        }
                                    }
                                    catch (Exception em2)
                                    {
                                        MessageBox.Show("error " + em2);
                                        throw;
                                    }
                                    conn3.Close();
                                }
                            }
                            catch (Exception em2)
                            {
                                MessageBox.Show("error "+ em2);
                                throw;
                            }


                            conn2.Close();
                        }
                        
                        
                    }
                    conn.Close();

                    /*if (datservicio == null || datservicio == 0)
                    {
                    conectarbd();

                    String updaservicio = "update casino " +
                                        " set servicio = " + turnoid +
                                        " where iduser = " + datiduser +
                                        " and fecha = " + bdmaxdatetime3 +
                                        " and sn = " + datsn;

                    SqlCommand cmdupd = new SqlCommand(updaservicio, conn);
                    cmdupd.ExecuteNonQuery();
                    conn.Close();
                    }*/
                }
                else
                {
                    DateTime dtcarga = DateTime.Now;
                    log(dtcarga + ": No se pudo establecer dia de consulta");
                    conn.Close();
                }
            }
            catch (Exception exm2)
            {
                DateTime dtex2 = DateTime.Now;
                string bderror2 = dtex2 + ": PRC-validaturnosvalidos - " + exm2.Message;
                log(bderror2);
                conn.Close();

                conectarbd();

                timer1.Enabled = false;
                timer1.Enabled = true;
            }
        }

        private void consultarrelojimpresora()
        {
            try
            {
                conectarbd();
                //String consulta11 = "select distinct ari.impresora " +
                //                    " from Machines m, " +
                //                    "     ASISTENCIA_RELOJ_IMP ari " +
                //                    " where m.sn = '" + datsn + "' " +
                //                    " and m.ip = ari.ipreloj";
                String consulta11 = "select distinct ari.impresora " +
                                    " from Machines m, " +
                                    "     ASISTENCIA_RELOJ_IMP ari " +
                                    " where m.sn = '"+ datsn + "' " +
                                    " and m.ip = ari.ipreloj";
                SqlCommand cmdconsulta11 = new SqlCommand(consulta11, conn);
                SqlDataReader reader11 = cmdconsulta11.ExecuteReader();

                if (reader11.HasRows)
                {
                    reader11.Read();
                    impresoraasociada = Convert.ToString(reader11[0]);
                    string [] armarut = impresoraasociada.Split(':');
                    impresoraasociada = armarut[0];
                    if (armarut[1] != "" && armarut[1] != null)
                    {
                        puertoimpresoraasociada = armarut[1];
                    }
           
                   // string NewString;
                   // NewString = armarut[0];
                   // MessageBox.Show("encontro impresora: " + impresoraasociada+ " con maquina " + datsn);
                    conn.Close();
                }
                else
                {
                    DateTime dtdatos1 = DateTime.Now;
                    log(dtdatos1 + ": No existen impresoras asociada a reloj: " + bdrelojasociado);
                    conn.Close();
                }
            }
            catch (Exception exmdatos1)
            {
                DateTime dtex211 = DateTime.Now;
                string bderror311 = dtex211 + ": PRC-consultarrelojimpresora - " + exmdatos1.Message;
                log(bderror311);
                conn.Close();

                conectarbd();
            }
        }

        private void armamensaje()
        {
            string Susuario = "Usuario";
            obtenerdatovale();
            formatearut();
            msg1 = "            Casino Ticket TotalPack             ";
            msg2 = "------------------------------------------------";
            msg3 = "        " + impdpto;
            msg4 = "------------------------------------------------";
            msg5 = "                                                ";
            msg6 = " " + Susuario + ": " + impnombre;
            msg7 = " Rut: " + rutFormateado;
            msg8 = " Fecha: " + bdmaxdatetime4;
            msg9 = " Hora: " + bdmaxdatetime1;
            msg10 = " Servicio: " + turnoname + " " + numeroticketxhoy + " de " + numeroticketxserv;
            msg11 = "                                                ";
            msg12 = "------------------------------------------------";
            msg13 = "                                                ";
            msg14 = "                                                ";
            msg15 = "                                                ";
        }

        private void obtenerdatovale()
        {
            try
            {
                conectarbd();
                String consdatovale = "select distinct usr.name, dpto.DEPTNAME, usr.ssn " +
                                   " from USERINFO usr, " +
                                   "      DEPARTMENTS dpto " +
                                   " where usr.userid = " + datiduser +
                                   " and usr.DEFAULTDEPTID = dpto.DEPTID";
                SqlCommand cmdconsdatovale = new SqlCommand(consdatovale, conn);
                SqlDataReader readerconsdatovale = cmdconsdatovale.ExecuteReader();

                if (readerconsdatovale.HasRows)
                {
                    readerconsdatovale.Read();
                    impnombre = Convert.ToString(readerconsdatovale[0]);
                    impdpto = Convert.ToString(readerconsdatovale[1]);
                    impssn = Convert.ToString(readerconsdatovale[2]);
                    conn.Close();
                }
                else
                {
                    DateTime dtdatos = DateTime.Now;
                    log(dtdatos + ": No existen datos para usuario");
                    conn.Close();
                }
            }
            catch (Exception exmdatos)
            {
                DateTime dtex21 = DateTime.Now;
                string bderror31 = dtex21 + ": PRC-obtenerdatovale - " + exmdatos.Message;
                log(bderror31);
                conn.Close();
            }
        }

        private void formatearut()
        {
            //rssn = "14160227-6";
            string[] armarut;
            armarut = impssn.Split('-');
            string NewString;
            NewString = armarut[0];
            if (armarut[1] != "") 
            {
                NewString += armarut[1];
            }
            else
            {
                NewString = "1";
            }
            //NewString += armarut[1];
            //string NewString = rssn.Trim(MyChar);
            //string rutSinFormato = "141602276";
            rutFormateado = String.Empty;

            //obtengo la parte numerica del RUT
            string rutTemporal = NewString.Substring(0, NewString.Length - 1);

            //obtengo el Digito Verificador del RUT
            string dv = NewString.Substring(NewString.Length - 1, 1);

            Int64 rut;

            //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
            if (!Int64.TryParse(rutTemporal, out rut))
            {
                rut = 0;
            }

            //este comando es el que formatea con los separadores de miles
            rutFormateado = rut.ToString("N0");

            if (rutFormateado.Equals("0"))
            {
                rutFormateado = string.Empty;
            }
            else
            {
                //si no hubo problemas con el formateo agrego el DV a la salida
                rutFormateado += "-" + dv;

                //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                //rutFormateado = rutFormateado.Replace(",", ".");
            }

            //la salida esperada para el ejemplo es 99.999.999-K
            //Response.Write("RUT Formateado: " + rutFormateado);
        }

        private void imprime()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.NoDelay = true;
                //MessageBox.Show("M");
                IPAddress ip = IPAddress.Parse(impresoraasociada);
                IPEndPoint ipep;
                if (puertoimpresoraasociada != " " && puertoimpresoraasociada != "" && puertoimpresoraasociada != null)
                {
                    int x = 0;

                    Int32.TryParse(puertoimpresoraasociada, out x);
                    ipep = new IPEndPoint(ip,x);
                }
                else
                {
                    ipep = new IPEndPoint(ip, 9100);
                }

                clientSocket.Connect(ipep);

                clientSocket.Send(cancelprint);
                clientSocket.Send(setfont2normal);
                byte[] usuarioimp1 = System.Text.Encoding.ASCII.GetBytes(msg1);
                clientSocket.Send(usuarioimp1);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp2 = System.Text.Encoding.ASCII.GetBytes(msg2);
                clientSocket.Send(usuarioimp2);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp3 = System.Text.Encoding.ASCII.GetBytes(msg3);
                clientSocket.Send(usuarioimp3);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp4 = System.Text.Encoding.ASCII.GetBytes(msg4);
                clientSocket.Send(usuarioimp4);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp5 = System.Text.Encoding.ASCII.GetBytes(msg5);
                clientSocket.Send(usuarioimp5);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp6 = System.Text.Encoding.ASCII.GetBytes(msg6);
                clientSocket.Send(usuarioimp6);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp7 = System.Text.Encoding.ASCII.GetBytes(msg7);
                clientSocket.Send(usuarioimp7);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp8 = System.Text.Encoding.ASCII.GetBytes(msg8);
                clientSocket.Send(usuarioimp8);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp9 = System.Text.Encoding.ASCII.GetBytes(msg9);
                clientSocket.Send(usuarioimp9);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp10 = System.Text.Encoding.ASCII.GetBytes(msg10);
                clientSocket.Send(usuarioimp10);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp11 = System.Text.Encoding.ASCII.GetBytes(msg11);
                clientSocket.Send(usuarioimp11);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp12 = System.Text.Encoding.ASCII.GetBytes(msg12);
                clientSocket.Send(usuarioimp12);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp13 = System.Text.Encoding.ASCII.GetBytes(msg13);
                clientSocket.Send(usuarioimp13);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp14 = System.Text.Encoding.ASCII.GetBytes(msg14);
                clientSocket.Send(usuarioimp14);
                clientSocket.Send(CarriageReturn);
                byte[] usuarioimp15 = System.Text.Encoding.ASCII.GetBytes(msg15);
                clientSocket.Send(usuarioimp15);
                clientSocket.Send(CarriageReturn);

                clientSocket.Send(commandCutPaper);

                clientSocket.Close();
            }
            catch (Exception eximp)
            {
                string errorimp = "Error al intentar imprimir, IP: " + impresoraasociada + " Error: " + eximp.Message;
                MessageBox.Show(errorimp);
                log(errorimp);
                clientSocket.Close();
            }
        }

        public void log(string text)
        {
            string archproclog = path + @"\RegistroLogsITC.log";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(archproclog, true))
            {
                file.WriteLine(text);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
