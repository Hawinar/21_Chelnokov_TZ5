using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SaveResults
{
    public static void Save()
    {
        int limitedCount = 10; //Будет выведен топ-{limitedCount} игроков

        List<ResultItem> results = new List<ResultItem>();

        //Получаем все не пустые PlayerPrefs
        for (int i = 0; i < limitedCount; i++)
        {
            if (PlayerPrefs.GetString($"Nickname_{i}") != "")
            {
                results.Add(new ResultItem() { nickname = PlayerPrefs.GetString($"Nickname_{i}"), score = PlayerPrefs.GetFloat($"Score_{i}") });
            }
        }

        //Сортировка 1
        results = results.OrderByDescending(x => x.score).ToList();

        //Во избежание дубликатов никнеймов, оставляем только лучший результат игрока
        for (int i = 0; i < results.Count; i++)
        {
            for (int j = 0; j < results.Count; j++)
            {
                if (i != j && results[i].nickname == results[j].nickname)
                    results.Remove(results[j]);
            }
        }

        //Добавляем результат текущего игрока
        results.Add(new ResultItem() { nickname = GameController.Nickname, score = GameController.Score });

        //Сортировка 2
        results = results.OrderByDescending(x => x.score).ToList();

        // Во избежание дубликатов никнеймов, оставляем только лучший результат игрока
        for (int i = 0; i < results.Count; i++)
        {
            for (int j = 0; j < results.Count; j++)
            {
                if (i != j && results[i].nickname == results[j].nickname)
                    results.Remove(results[j]);
            }
        }

        //Отсеивание лишних.
        //В ходе сортировки 2 и данного отсеивания,
        //результат игрока может и не попасть в список лидеров, если результат не соответствуюет критериями,
        //например, слишком мало очков набрано.

        for (int i = results.Count - 1; i >= limitedCount; i--)
        {
            results.Remove(results[i]);
        }

        //Занесение в PlayerPrefs
        for (int i = 0; i < results.Count; i++)
        {
            PlayerPrefs.SetString($"Nickname_{i}", results[i].nickname);
            PlayerPrefs.SetFloat($"Score_{i}", results[i].score);
        }

    }
    class ResultItem
    {
        public string nickname { get; set; }
        public float score { get; set; }
    }
}
