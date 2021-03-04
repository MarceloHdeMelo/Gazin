using API_Crud_Gazin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Crud_Gazin.Aplicacao
{
    public class DeveloperAplicacao
    {
        private ApiContext _contexto;

        public DeveloperAplicacao(ApiContext contexto)
        {
            _contexto = contexto;
        }

        public string InserirDeveloper(Developer developer)
        {
            try
            {
                if (developer != null)
                {
                    var developerExiste = ObterDeveloperPorNome(developer.Nome);

                    if (developerExiste == null)
                    {
                        _contexto.Add(developer);
                        _contexto.SaveChanges();

                        return "Developer cadastrado com sucesso!";
                    }
                    else
                    {
                        return "Developer já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "Developer inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível comunicar-se com a base de dados!";
            }
        }

        public string AtualizarDeveloper(Developer developer)
        {
            try
            {
                if (developer != null)
                {
                    _contexto.Update(developer);
                    _contexto.SaveChanges();

                    return "Developer alterado com sucesso!";
                }
                else
                {
                    return "Developer inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível comunicar-se com a base de dados!";
            }
        }

        public List<Developer> ObterTodosDevelopers()
        {
            List<Developer> listaDeDevelopers = new List<Developer>();
            try
            {

                listaDeDevelopers = _contexto.Developer.Select(x => x).ToList();

                if (listaDeDevelopers != null)
                {
                    return listaDeDevelopers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string DeletarDeveloper(Developer developer)
        {
            try
            {
                if (developer != null)
                {
                    _contexto.Developer.Remove(developer);
                    _contexto.SaveChanges();

                    return "Developer " + developer.Nome + " deletado com sucesso!";
                }
                else
                {
                    return "Developer não cadastrado!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível comunicar-se com a base de dados!";
            }
        }

        public Developer ObterDeveloperPorNome(string nome)
        {
            Developer primeiroDeveloper = new Developer();

            try
            {
                if (String.IsNullOrEmpty(nome))
                {
                    return null;
                }

                var developer = _contexto.Developer.Where(x => x.Nome == nome).ToList();
                primeiroDeveloper = developer.FirstOrDefault();

                if (primeiroDeveloper != null)
                {
                    return primeiroDeveloper;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
