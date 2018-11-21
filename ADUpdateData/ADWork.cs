using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace ADUpdateData
{
    /// <summary>
    /// Classe para atualizar o AD
    /// </summary>
    public class ADWork
    {
        #region Declarations
        public enum ADS_USER_FLAG
        { 
            ADS_UF_SCRIPT                                  = 1,        // 0x1
            ADS_UF_ACCOUNTDISABLE                          = 2,        // 0x2
            ADS_UF_HOMEDIR_REQUIRED                        = 8,        // 0x8
            ADS_UF_LOCKOUT                                 = 16,       // 0x10
            ADS_UF_PASSWD_NOTREQD                          = 32,       // 0x20
            ADS_UF_PASSWD_CANT_CHANGE                      = 64,       // 0x40
            ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED         = 128,      // 0x80
            ADS_UF_TEMP_DUPLICATE_ACCOUNT                  = 256,      // 0x100
            ADS_UF_NORMAL_ACCOUNT                          = 512,      // 0x200
            ADS_UF_INTERDOMAIN_TRUST_ACCOUNT               = 2048,     // 0x800
            ADS_UF_WORKSTATION_TRUST_ACCOUNT               = 4096,     // 0x1000
            ADS_UF_SERVER_TRUST_ACCOUNT                    = 8192,     // 0x2000
            ADS_UF_DONT_EXPIRE_PASSWD                      = 65536,    // 0x10000
            ADS_UF_MNS_LOGON_ACCOUNT                       = 131072,   // 0x20000
            ADS_UF_SMARTCARD_REQUIRED                      = 262144,   // 0x40000
            ADS_UF_TRUSTED_FOR_DELEGATION                  = 524288,   // 0x80000
            ADS_UF_NOT_DELEGATED                           = 1048576,  // 0x100000
            ADS_UF_USE_DES_KEY_ONLY                        = 2097152,  // 0x200000
            ADS_UF_DONT_REQUIRE_PREAUTH                    = 4194304,  // 0x400000
            ADS_UF_PASSWORD_EXPIRED                        = 8388608,  // 0x800000
            ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION  = 16777216 // 0x1000000
        };
        /// <summary>
        /// Endereços das OUs que devem ser atualizadas no AD.
        /// </summary>
        private DataGridView m_LdapStrings;
        /// <summary>
        /// Usuário que irá atualizar o AD.
        /// </summary>
        private String m_Username;
        /// <summary>
        /// Senha do usuário que irá atualizar o AD.
        /// </summary>
        private String m_Password;

        #endregion

        #region Methods
        /// <summary>
        /// Classe para atualização do AD.
        /// </summary>
        /// <param name="ldapStrings">Endereços das OUs que devem ser atualizadas no AD.</param>
        /// <param name="username">Usuário com permissão para atualizar o AD.</param>
        /// <param name="password">Senha do usuário com permissão para atualizar o AD.</param>
        public ADWork(DataGridView ldapStrings, String username, String password)
        {
            m_LdapStrings = ldapStrings;
            m_Username = username;
            m_Password = password;
        }
        /// <summary>
        /// Atualiza o AD.
        /// </summary>
        /// <param name="objectFilter">Filtro seletor dos objetos que devem ser atualizados (CN).</param>
        /// <param name="objectName">Nome da propriedade que deve ser atualizada.</param>
        /// <param name="objectValue">Novo valor da propriedade.</param>
        /// <param name="ldapDomain">Domínio em que deve ocorrer a atualização.</param>
        /// <returns>Retorna o conteúdo original da propriedade antes da atualização.</returns>
        public KeyValuePair<Tuple<String, String>, Tuple<String, String>> SetADInfo(string objectFilter, String objectName, string objectValue, string ldapDomain, String ADFilterField, Boolean allowBlankField)
        {
            KeyValuePair<Tuple<String, String>, Tuple<String, String>> resultado = new KeyValuePair<Tuple<String, String>, Tuple<String, String>>();
            foreach (DataGridViewRow dr in m_LdapStrings.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    string connectionPrefix = dr.Cells[0].Value.ToString();
                    DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
                    entry.AuthenticationType = AuthenticationTypes.None;
                    entry.Username = m_Username;
                    entry.Password = m_Password;
                    DirectorySearcher mySearcher = new DirectorySearcher(entry);
                    //mySearcher.Filter = "(cn=" + objectFilter + ")";
                    mySearcher.Filter = "(&(objectCategory=User)(" + ADFilterField + "=" + objectFilter + "))";
                    mySearcher.PropertiesToLoad.Add("" + objectName + "");
                    try
                    {
                        SearchResult result = mySearcher.FindOne();
                        if (result != null)
                        {
                            DirectoryEntry entryToUpdate = result.GetDirectoryEntry();
                            if (String.IsNullOrEmpty(objectValue) && allowBlankField == false)
                            {
                            }
                            else
                            {
                                Tuple<String, String> key = new Tuple<String, String>(objectFilter, objectName);
                                Tuple<String, String> value;

                                if (objectName.ToLower() == "manager" || objectName.ToLower() == "assistant" || objectName.ToLower() == "secretary")
                                {
                                    DirectoryEntry boss =
                                        GetADInfo(objectValue, "cn", objectValue, ADFilterField).GetDirectoryEntry();
                                    objectValue = boss.Properties["distinguishedname"].Value.ToString();
                                }

                                if (objectName.ToLower() == "thumbnailPhoto")
                                {
                                    
                                }

                                if (result.Properties.Contains("" + objectName + ""))
                                {
                                    value = new Tuple<String, String>(entryToUpdate.Properties["" + objectName + ""].Value.ToString(), objectValue);
                                    entryToUpdate.Properties["" + objectName + ""].Value = objectValue;

                                }
                                else
                                {
                                    value = new Tuple<String, String>("", objectValue);
                                    entryToUpdate.Properties["" + objectName + ""].Add(objectValue);
                                }
                                resultado = new KeyValuePair<Tuple<String, String>, Tuple<String, String>>(key, value);
                                try
                                {
                                    entryToUpdate.CommitChanges();
                                }
                                catch
                                {
                                }
                            }
                        }

                        entry.Close();
                        entry.Dispose();
                        mySearcher.Dispose();
                    }
                    catch
                    {
                    }
                }
            }
            return resultado;
        }

        public KeyValuePair<String, Boolean> EnableUser(string objectFilter, String objectName, Boolean enable, string ldapDomain, String ADFilterField)
        {
            KeyValuePair<String, Boolean> resultado = new KeyValuePair<String, Boolean>();
            foreach (DataGridViewRow dr in m_LdapStrings.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    string connectionPrefix = dr.Cells[0].Value.ToString();
                    DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
                    entry.AuthenticationType = AuthenticationTypes.None;
                    entry.Username = m_Username;
                    entry.Password = m_Password;
                    DirectorySearcher mySearcher = new DirectorySearcher(entry);
                    //mySearcher.Filter = "(cn=" + objectFilter + ")";
                    mySearcher.Filter = "(&(objectCategory=User)(" + ADFilterField + "=" + objectFilter + "))";
                    mySearcher.PropertiesToLoad.Add("" + objectName + "");
                    try
                    {
                        SearchResult result = mySearcher.FindOne();
                        if (result != null)
                        {
                            DirectoryEntry entryToUpdate = result.GetDirectoryEntry();

                                String key = objectFilter;
                                Boolean value = enable;

                            if (enable)
                            {
                                int val = (int) entryToUpdate.Properties["userAccountControl"].Value;
                                entryToUpdate.Properties["userAccountControl"].Value = val & ~((int)(ADS_USER_FLAG.ADS_UF_ACCOUNTDISABLE));
                            }

                            else
                            {
                                int val = (int)entryToUpdate.Properties["userAccountControl"].Value;
                                entryToUpdate.Properties["userAccountControl"].Value = val | ((int)(ADS_USER_FLAG.ADS_UF_ACCOUNTDISABLE));
                            }

                            resultado = new KeyValuePair<String, Boolean>(key, value);
                            try
                            {
                                entryToUpdate.CommitChanges();
                            }
                            catch
                            {
                            }
                        }

                        entry.Close();
                        entry.Dispose();
                        mySearcher.Dispose();
                    }
                    catch
                    {
                    }
                }
            }
            return resultado;
        }

        public SearchResult GetADInfo(string objectFilter, String objectName, string objectValue, String ADFilterField)
        {
            SearchResult result = null;

            foreach (DataGridViewRow dr in m_LdapStrings.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    string connectionPrefix = "";
                    if (String.IsNullOrEmpty(connectionPrefix))
                    {
                        dr.Cells[0].Value.ToString();
                    }
                    DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
                    entry.AuthenticationType = AuthenticationTypes.None;
                    entry.Username = m_Username;
                    entry.Password = m_Password;
                    DirectorySearcher mySearcher = new DirectorySearcher(entry);
                    //mySearcher.Filter = "(cn=" + objectFilter + ")";
                    mySearcher.Filter = "(&(objectCategory=User)(" + ADFilterField + "=" + objectFilter + "))";
                    mySearcher.PropertiesToLoad.Add("" + objectName + "");
                    result = mySearcher.FindOne();
                }
                if (result != null)
                    break;
            }
            return result;
        }
        /// <summary>
        /// Lista os usuários do AD.
        /// </summary>
        /// <returns>Uma lista de nomes de usuário.</returns>
        public IEnumerable<String> ListADInfo()
        {
            List<String> users = new List<string>();
            foreach (DataGridViewRow dr in m_LdapStrings.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    string connectionPrefix = dr.Cells[0].Value.ToString();
                    DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
                    entry.AuthenticationType = AuthenticationTypes.None;
                    entry.Username = m_Username;
                    entry.Password = m_Password;
                    DirectorySearcher mySearcher = new DirectorySearcher(entry);
                    mySearcher.Filter = "(objectCategory=User)";
                    //mySearcher.PropertiesToLoad.Add("" + objectName + "");
                    
                    SearchResultCollection results = mySearcher.FindAll();
                    if (results.Count > 0)
                    {
                        foreach (SearchResult result in results)
                        {
                            if (result.Properties["cn"][0] != null)
                            {
                                String username = result.Properties["cn"][0].ToString();
                                if (!users.Contains(username))
                                {
                                    users.Add(username);
                                }
                            }
                        }
                    }

                    entry.Close();
                    entry.Dispose();
                    mySearcher.Dispose();
                }
            }
            return users;
        }


        #endregion
    }
}