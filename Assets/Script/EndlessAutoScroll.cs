using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndlessAutoScroll : MonoBehaviour
{

    [SerializeField] GameObject[] nodes;
    [SerializeField] RectTransform content;
    [SerializeField] int numberOfNode = 12;
    [SerializeField] float scrollSpeed = 5;
    [SerializeField] bool isReverse;

    Vector3 contentPosition;
    float nodeHeight;
    float nodeSpace;
    int loopCount;

    void Start()
    {
        if (content.childCount == 0)
        {
            createNodesFromPrefabs();
        }
        else
        {
            getChildrenInContent();
        }

        loopCount = numberOfNode - 1;

        contentPosition = content.localPosition;
    }

    void Update()
    {
        loopContent();
    }

    void loopContent()
    {
        if (!isReverse)
        {
            upScroll();
        }
        else
        {
            downScroll();
        }
    }

    void getChildrenInContent()
    {
        var childrenNode = new List<GameObject>();
        for (int i = 0; i < content.childCount; i++)
        {
            childrenNode.Add(content.GetChild(i).gameObject);
        }
        nodes = childrenNode.ToArray();
        numberOfNode = nodes.Length;


        nodeHeight = nodes[0].GetComponent<LayoutElement>().minHeight;
        nodeSpace = content.GetComponent<VerticalLayoutGroup>().spacing;

        nodes[numberOfNode - 1].transform.SetAsFirstSibling();
        content.transform.localPosition += Vector3.up * (nodeHeight + nodeSpace);
    }

    void createNodesFromPrefabs()
    {
        nodes = new GameObject[numberOfNode];

        var node = Resources.Load("Prefabs/Node") as GameObject;

        nodeHeight = node.GetComponent<LayoutElement>().minHeight;
        nodeSpace = content.GetComponent<VerticalLayoutGroup>().spacing;

        for (int i = 0; i < numberOfNode; i++)
        {
            nodes[i] = Instantiate(node, content, false) as GameObject;

            var nodeText = nodes[i].GetComponentInChildren<Text>();
            nodeText.text = "Content " + i;

            if (i == nodes.Length - 1)
            {
                nodes[i].transform.SetAsFirstSibling();
                content.transform.localPosition += Vector3.up * (nodeHeight + nodeSpace);
            }
        }
    }

    void upScroll()
    {
        content.transform.localPosition += Vector3.up * scrollSpeed;

        if (content.transform.localPosition.y >= contentPosition.y + (nodeHeight + nodeSpace))
        {
            nodes[loopCount].transform.SetAsLastSibling();
            loopCount++;

            if (loopCount == numberOfNode)
            {
                loopCount = 0;
            }

            content.transform.localPosition = contentPosition;
        }
    }

    void downScroll()
    {
        content.transform.localPosition -= Vector3.up * scrollSpeed;

        if (content.transform.localPosition.y <= contentPosition.y - (nodeHeight + nodeSpace))
        {
            if (loopCount == 0)
            {
                loopCount = numberOfNode;
            }

            loopCount--;
            nodes[loopCount].transform.SetAsFirstSibling();

            content.transform.localPosition = contentPosition;
        }
    }
}
