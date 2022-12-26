using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPlanner : MonoBehaviour
{
    public List<RoboticAgent> agents;

    private List<AgentTrajectory> _trajectories;
    private GeneticPathPlanner _planner;

    void Awake()
    {
        _planner = new GeneticPathPlanner();
        foreach (RoboticAgent agent in agents)
        {
            _planner.SetPath(agent);
        }
    }
    
    void Update()
    {
        
    }
}

public class AgentTrajectory
{
    
}

public class GeneticPathPlanner
{
    private int _stepsCount = 20;
    
    private List<AgentTrajectory> _trajectories;
    
    public void SetPath(RoboticAgent agent)
    {
        Vector3 start = agent.StartPosition;
        Vector3 finish = agent.TargetPosition;

        float distance = Vector3.Distance(start, finish);
        Vector3 direction = (finish - start).normalized;

        float oneStepLength = distance / _stepsCount;


        Vector3 initPos = direction * oneStepLength;
        
        agent.trajectory.Add(start);
        
        for (int i = 1; i < _stepsCount; i++)
        {
            agent.trajectory.Add(agent.trajectory[i-1] + initPos);
        }
    }
}
