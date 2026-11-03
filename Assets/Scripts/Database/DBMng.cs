using UnityEngine;

public static class DBMng
{
    private const string OVOS_LEVEL = "ovos-level-";
    private const string MOEDAS_LEVEL = "moedas-level-";
    private const string OVO_FINAL_LEVEL = "ovo-final-level-";
    private const string LEVEL_DESBLOQUEADO = "level_desbloqueado-";
    private const string CONFIGURACOES = "configuracoes";
    private const string VOLUME = "volume";

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

    public static void SetVolume(float volumeVFX, float volumeMusica)
    {
        //Criar um objeto Volume para armazenar os dados
        Volume volume = new Volume();

        //Armazenar os valores dos parametros no objeto do volume
        volume.vfx = volumeVFX;
        volume.musica = volumeMusica;

        //Converter o objeto para uma estrutura em Json
        string json = JsonUtility.ToJson(volume);

        //Salvar json na memoria
        PlayerPrefs.SetString(VOLUME, json);
    }

    public static Volume GetVolume()
    {
        //Pegar a estrutura salva do json na memoria
        string json = PlayerPrefs.GetString(VOLUME);

        //Converter a estrutura para o objeto Volume
        Volume volume = JsonUtility.FromJson<Volume>(json);

        //Verificar se o volume está nulo
        if (volume == null)
        {
            //Salvar um volume inicial
            SetVolume(0.5f, 0.5f);

            //Atualizar a estrutura do json
            json = PlayerPrefs.GetString(VOLUME);

            //Converter a estrutura atualizada para o objeto volume
            volume = JsonUtility.FromJson<Volume>(json);
        }

        //Retornar o volume configurado
        return volume;
    }
}
