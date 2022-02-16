using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManager : MonoBehaviour
{
    // 组件
    public GameObject pipelineTemplate;
    public List<Pipeline> pipelines;

    // 协程
    Coroutine coroutine = null;

    public void Init()
    {
        for (int i = 0; i < pipelines.Count; ++i)
        {
            Destroy(pipelines[i].gameObject);
        }
        pipelines.Clear();
    }

    public void StartRun()
    {
        coroutine = StartCoroutine(GeneratePipelines());
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < pipelines.Count; ++i)
        {
            pipelines[i].enabled = false;
        }
    }

    IEnumerator GeneratePipelines()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (pipelines.Count < 3)
            {
                GeneratePipeline();

            }
            else
            {
                pipelines[i].enabled = true;
                pipelines[i].Init();
            }

            yield return new WaitForSeconds(2f);
        }
    }

    void GeneratePipeline()
    {
        if (pipelines.Count < 3)
        {
            GameObject obj = Instantiate(pipelineTemplate, this.transform);
            Pipeline p = obj.GetComponent<Pipeline>();
            pipelines.Add(p);
        }
    }
}
