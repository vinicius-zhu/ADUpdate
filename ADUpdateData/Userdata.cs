using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace ADUpdateData
{
    /// <summary>
    /// Usuário do AD.
    /// </summary>
    public class Userdata : IEquatable<Userdata>
    {
        #region Declarations
        /// <summary>
        /// Lista de atributos e seus valores de um usuário do AD.
        /// </summary>
        public Dictionary<String, String> Attribute
        {
            get { return m_Attribute; }
        }
        /// <summary>
        /// Acessa os atributos do usuário.
        /// </summary>
        /// <param name="key">Nome do atributo.</param>
        /// <returns>Valor do atributo.</returns>
        public String this[String key]
        {
            get { return Attribute[key]; }
        }
        private Dictionary<String, String> m_Attribute = new Dictionary<string,string>();
        #endregion

        #region Methods
        /// <summary>
        /// Preenche os dados de um usuário do AD a partir de uma lista de campos e de uma query no Oracle com os valores destes campos.
        /// </summary>
        /// <param name="dr">DataReader aberto com as informações dos usuários.</param>
        /// <param name="listfields">Lista de campos cujos valores serão armazenados para o usuário.</param>
        public Userdata(OracleDataReader dr, List<String> listfields)
        {
            for (Int32 i = 0; i < listfields.Count; i++)
            {
                if (m_Attribute.ContainsKey(listfields[i]))
                {
                    m_Attribute[listfields[i]] = dr[listfields[i]].ToString();
                }
                else
                {
                    try
                    {
                        m_Attribute.Add(listfields[i], dr[listfields[i]].ToString());
                    }
                    catch
                    {
                        m_Attribute.Add(listfields[i], "");
                    }
                }
            }
        }
        /// <summary>
        /// Cria uma instância vazia da classe Userdata.
        /// </summary>
        public Userdata()
        {
            
        }
        /// <summary>
        /// Verifica se o usuário tem um atributo.
        /// </summary>
        /// <param name="key">Nome do atributo.</param>
        /// <returns>Verdadeiro se existe o atributo. Falso se não existe.</returns>
        public Boolean ContainsKey(String key)
        {
            return Attribute.ContainsKey(key);
        }
        #endregion

        #region Operators
        /// <summary>
        /// Compara dois Userdata.
        /// </summary>
        /// <param name="a">Primeiro usuário.</param>
        /// <param name="b">Segundo usuário.</param>
        /// <returns>True se tiverem o mesmo nome de usuário ou se todos os atributos forem iguais. False do contrário.</returns>
        public static Boolean operator ==(Userdata a, Userdata b)
        {
            if (a.Attribute.ContainsKey("cn") && b.Attribute.ContainsKey("cn"))
            {
                if (a.Attribute["cn"] == b.Attribute["cn"])
                {
                    return true;
                }
            }
            else
            {
                foreach (KeyValuePair<String, String> kp in a.Attribute)
                {
                    if (!b.Attribute.ContainsKey(kp.Key))
                    {
                        return false;
                    }
                    else
                    {
                        if (b.Attribute[kp.Key] != kp.Value)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compara dois Userdata.
        /// </summary>
        /// <param name="a">Primeiro usuário.</param>
        /// <param name="b">Segundo usuário.</param>
        /// <returns>False se tiverem o mesmo nome de usuário ou se todos os atributos forem iguais. True do contrário.</returns>
        public static bool operator !=(Userdata a, Userdata b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Compara dois Userdata.
        /// </summary>
        /// <param name="other">Usuário.</param>
        /// <returns>True se tiverem o mesmo nome de usuário ou se todos os atributos forem iguais. False do contrário.</returns>
        public bool Equals(Userdata other)
        {
            return this == other;
        }
        /// <summary>
        /// Compara dois Userdata.
        /// </summary>
        /// <param name="o">Usuário.</param>
        /// <returns>True se tiverem o mesmo nome de usuário ou se todos os atributos forem iguais. False do contrário.</returns>
        public override bool Equals(object o)
        {
            return Equals((Userdata) o);
        }
        /// <summary>
        /// Retorna o HashCode
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return Attribute.GetHashCode();
        }
        #endregion
    }

    public class UserdataUsername : EqualityComparer<Userdata>
    {
        public override bool Equals(Userdata x, Userdata y)
        {
            if (x.ContainsKey("cn") && y.ContainsKey("cn"))
            {
                Userdata a = new Userdata();
                Userdata b = new Userdata();
                a.Attribute.Add("cn", x["cn"]);
                b.Attribute.Add("cn", y["cn"]);
                return a == b;
            }
            return x == y;
        }

        public override int GetHashCode(Userdata obj)
        {
            Userdata a = new Userdata();
            if (obj.ContainsKey("cn"))
            {
                a.Attribute.Add("cn", obj["cn"]);
            }
            return a.GetHashCode();
        }
    }
}
