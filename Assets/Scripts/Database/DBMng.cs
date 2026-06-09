using UnityEngine;

public static class DBMng
{
    private const string OVOS_LEVEL = "ovos-level-";
    private const string MOEDAS_LEVEL = "moedas-level-";
    private const string OVO_FINAL_LEVEL = "ovo-final-level-";
    private const string LEVEL_DESBLOQUEADO = "level_desbloqueado-";
    private const string CONFIGURACOES = "configuracoes";

    public static int ObterOvosLevel(int id)
    {
        return PlayerPrefs.GetInt(OVOS_LEVEL + id);
    }

    public static int ObterMoedasLevel(int id)
    {
        return PlayerPrefs.GetInt(MOEDAS_LEVEL + id);
    }

    public static bool ObterLevelDesbloqueado(int id)
    {
        return PlayerPrefs.GetInt(LEVEL_DESBLOQUEADO + id) == 1;
    }

    public static int ObterOvoFinalLevel(int id)
    {
        int ovosLevel = PlayerPrefs.GetInt(OVO_FINAL_LEVEL + id);
        if(ovosLevel == 0)
        {
            PlayerPrefs.SetInt(OVO_FINAL_LEVEL + id,4);
        }
        return PlayerPrefs.GetInt(OVO_FINAL_LEVEL + id);
    }

    public static void Save(int idLevel, int ovos, int moedas, int ovoFinal)
    {
        //Obter dados atual do level
        int ovosLevel = ObterOvosLevel(idLevel);
        int moedasLevel = ObterMoedasLevel(idLevel);
        int ovoFinalLevel = ObterOvoFinalLevel(idLevel);
        //Verificar se os novos ovos coletados foram maior que anteriomente
        if (ovos > ovosLevel)
        {
            //Atualizar os dados dos novos ovos do level
            PlayerPrefs.SetInt(OVOS_LEVEL + idLevel, ovos);
        }

        if (moedas > moedasLevel)
        {
            PlayerPrefs.SetInt(MOEDAS_LEVEL + idLevel, moedas);
        }

        if (ovoFinal < ovoFinalLevel)
        {
            PlayerPrefs.SetInt(OVO_FINAL_LEVEL + idLevel, ovoFinal);
        }

        //Desbloquear o próximo level
        PlayerPrefs.SetInt(LEVEL_DESBLOQUEADO + (idLevel + 1), 1);
    }
}
