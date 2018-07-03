using GameFramework;
using System;
using System.Collections.Generic;

namespace GameMain
{
    public class TaskManager : Singleton<TaskManager>
    {
        public ITask CurThreadTask { get; private set; }
        public ITask CurBranchTask { get; private set; }
        public TaskFindLocation CurFindLocation { get; private set; }

        private List<int> m_ThreadTaskList;
        private List<int> m_BranchTaskList;
        private List<int> m_DailyTaskList;
        private TaskData m_CurThreadTaskCfg;
        private TaskData m_CurBranchTaskCfg;
        private DBTask m_TaskDB;

        public override void Init()
        {
            m_ThreadTaskList = new List<int>();
            m_BranchTaskList = new List<int>();
            m_DailyTaskList = new List<int>();
            m_CurThreadTaskCfg = new TaskData();
            m_CurBranchTaskCfg = new TaskData();
            CurFindLocation = new TaskFindLocation();
            m_TaskDB = GameEntry.Database.GetDBTable<DBTask>().GetDBRow(GameEntry.Database.GetUserId());

        }

        public void InitData()
        {
            InitThreadTaskData();
            InitBranchTaskData();
        }

        private void InitThreadTaskData()
        {
            if (m_TaskDB == null)
            {
                Log.Error("The Task DB is null");
                return;
            }

            if (m_TaskDB.ThreadTaskID == 0)
            {
                m_TaskDB.ThreadTaskID = m_ThreadTaskList[0];
            }

            LoadTaskScriptByTaskID(ref m_CurThreadTaskCfg, m_TaskDB.ThreadTaskID);
            this.LoadThreadTask();
        }

        private void InitBranchTaskData()
        {
            if (m_TaskDB == null)
            {
                Log.Error("The Task DB is null");
                return;
            }

            if (m_TaskDB.BranchTaskID == 0)
            {
                return;
            }

            LoadTaskScriptByTaskID(ref m_CurThreadTaskCfg, m_TaskDB.BranchTaskID);
            this.LoadBranchTask();
        }

        private void LoadThreadTask()
        {
            if (m_TaskDB.ThreadTaskStep >= m_CurThreadTaskCfg.SubTasks.Count)
            {
                m_TaskDB.ThreadTaskID++;
                m_TaskDB.ThreadTaskStep = 0;
                LoadTaskScriptByTaskID(ref m_CurThreadTaskCfg, m_TaskDB.ThreadTaskID);
            }

            if (m_CurThreadTaskCfg.SubTasks.Count > 0 && m_TaskDB.ThreadTaskStep < m_CurThreadTaskCfg.SubTasks.Count)
            {
                CreateSubTask(m_CurThreadTaskCfg.SubTasks[m_TaskDB.ThreadTaskStep], m_TaskDB.ThreadTaskID, m_TaskDB.ThreadTaskStep);
            }
            else
            {
                CurThreadTask = null;
            }
        }

        private void LoadBranchTask()
        {
            if (m_TaskDB.BranchTaskID >= m_CurBranchTaskCfg.SubTasks.Count)
            {
                m_TaskDB.BranchTaskID++;
                m_TaskDB.BranchTaskStep = 0;
                LoadTaskScriptByTaskID(ref m_CurBranchTaskCfg, m_TaskDB.BranchTaskID);
            }

            if (m_CurBranchTaskCfg.SubTasks.Count > 0 && m_TaskDB.BranchTaskStep < m_CurBranchTaskCfg.SubTasks.Count)
            {
                CreateSubTask(m_CurBranchTaskCfg.SubTasks[m_TaskDB.BranchTaskStep], m_TaskDB.BranchTaskID, m_TaskDB.BranchTaskStep);
            }
            else
            {
                CurBranchTask = null;
            }
        }

        private void CreateSubTask(SubTaskBase pData, int pTaskID, int pTaskStep)
        {
            switch (pData.Func)
            {
                case TaskSubFuncType.TYPE_TALK:
                    {
                        TaskTalk task = new TaskTalk();
                        CurThreadTask = task;
                        task.Accept(pData as SubTalk, pTaskID, pTaskStep);
                    }
                    break;
                case TaskSubFuncType.TYPE_HUNTER:
                    {
                        TaskKillMonster task = new TaskKillMonster();
                        CurThreadTask = task;
                        task.Accept(pData as SubKillMonster, pTaskID, pTaskStep);
                    }
                    break;
                case TaskSubFuncType.TYPE_COLLECT:
                    {
                        TaskCollectItem task = new TaskCollectItem();
                        CurThreadTask = task;
                        task.Accept(pData as SubCollectItem, pTaskID, pTaskStep);
                    }
                    break;
                case TaskSubFuncType.TYPE_INTERACTIVE:
                    {
                        TaskInterActive task = new TaskInterActive();
                        CurThreadTask = task;
                        task.Accept(pData as SubInterActive, pTaskID, pTaskStep);
                    }
                    break;
                case TaskSubFuncType.TYPE_CONVOY:
                    {
                        TaskConvoy task = new TaskConvoy();
                        CurThreadTask = task;
                        task.Accept(pData as SubConvoy, pTaskID, pTaskStep);
                    }
                    break;
                case TaskSubFuncType.TYPE_STORY:
                    {
                        TaskTriggerPlot task = new TaskTriggerPlot();
                        CurThreadTask = task;
                        task.Accept(pData as SubTriggerPlot, pTaskID, pTaskStep);
                    }
                    break;
                case TaskSubFuncType.TYPE_CUTSCENE:
                    {
                        TaskTriggerCutscene task = new TaskTriggerCutscene();
                        CurThreadTask = task;
                        task.Accept(pData as SubTriggerCutscene, pTaskID, pTaskStep);
                    }
                    break;
                case TaskSubFuncType.TYPE_USEITEM:
                    {
                        TaskUseItem task = new TaskUseItem();
                        CurThreadTask = task;
                        task.Accept(pData as SubUseItem, pTaskID, pTaskStep);
                    }
                    break;
                case TaskSubFuncType.TYPE_USESKILL:
                    {
                        TaskUseSkill task = new TaskUseSkill();
                        CurThreadTask = task;
                        task.Accept(pData as SubUseSkill, pTaskID, pTaskStep);
                    }
                    break;
                case TaskSubFuncType.TYPE_GATHER:
                    {
                        TaskGather task = new TaskGather();
                        CurThreadTask = task;
                        task.Accept(pData as SubGather, pTaskID, pTaskStep);
                    }
                    break;
                default:
                    {
                        CurThreadTask = null;
                    }
                    break;
            }

        }

        private void LoadTaskScriptByTaskID(ref TaskData data, int pTaskID)
        {
            data.SubTasks.Clear();
            data.Load(GlobalTools.Format("Text/Task/{0}", pTaskID));
        }

        public List<int> GetAllTaskByTaskType(TaskType type)
        {
            switch (type)
            {
                case TaskType.THREAD:
                    return m_ThreadTaskList;
                case TaskType.BRANCH:
                    return m_BranchTaskList;
                case TaskType.DAILY:
                    return m_DailyTaskList;
            }
            return null;
        }

        public List<int> GetDisplayTaskListByType(TaskType type)
        {
            List<int> list = new List<int>();
            switch (type)
            {
                case TaskType.THREAD:
                    {
                        if (CurThreadTask != null)
                        {
                            list.Add(m_TaskDB.ThreadTaskID);
                        }
                    }
                    break;
                case TaskType.BRANCH:
                    {
                        if (m_TaskDB != null)
                        {
                            list.Add(m_TaskDB.BranchTaskID);
                        }
                    }
                    break;
                case TaskType.DAILY:
                    {

                    }
                    break;
            }
            return list;
        }

        public void TriggerTaskByTargetType(TaskTargetType type, int count)
        {
            //Dictionary<int, DBTask>.Enumerator em = ZTConfig.Instance.DictTask.GetEnumerator();
            //int pRoleLevel = DataManager.Instance.GetCurRole().Level;
            //while (em.MoveNext())
            //{
            //    DBTask db = em.Current.Value;
            //    int taskID = em.Current.Key;
            //    if (db.TargetType != type)
            //    {
            //        continue;
            //    }
            //    if (db.MinRquireLevel > pRoleLevel)
            //    {
            //        continue;
            //    }
            //    if (db.MaxRquireLevel > 0 && pRoleLevel > db.MaxRquireLevel)
            //    {
            //        continue;
            //    }
            //    switch (em.Current.Value.Type)
            //    {
            //        case TaskType.DAILY:
            //            {
            //                XDailyTask data = DataManager.Instance.GetDailyTaskDataById(taskID);
            //                if (data == null)
            //                {
            //                    data = new XDailyTask();
            //                    data.Id = taskID;
            //                    data.State = (int)TaskState.QUEST_DOING;
            //                }
            //                data.Count += count;
            //                if (data.Count >= db.Condition)
            //                {
            //                    data.Count = count;
            //                    data.State = (int)TaskState.QUEST_CANSUBMIT;
            //                }
            //                DataManager.Instance.DataDailyTask.Update(taskID, data);
            //            }
            //            break;
            //    }

            //}
            //em.Dispose();
        }

        public void RecvSubmitTask(int pTaskID, int pSubIndex)
        {
            //DBTask db = ZTConfig.Instance.GetDBTask(pTaskID);
            //switch (db.Type)
            //{
            //    case TaskType.THREAD:
            //        {
            //            CurThreadData.CurTaskStep++;
            //            DataManager.Instance.DataThreadTask.Update(Define.TASK_THREAD_DATA_KEY, CurThreadData);
            //            LoadThreadTask();
            //            ZTEvent.FireEvent(EventID.UPDATE_THREAD_TASK_STATE);
            //            if (pSubIndex < m_CurThreadCfg.SubTasks.Count)
            //            {
            //                return;
            //            }
            //        }
            //        break;
            //    case TaskType.BRANCH:
            //        {

            //        }
            //        break;
            //    case TaskType.DAILY:
            //        {
            //            XDailyTask data = DataManager.Instance.GetDailyTaskDataById(pTaskID);
            //            data.State = (int)TaskState.QUEST_HASSUBMIT;
            //            DataManager.Instance.DataDailyTask.Update(pTaskID, data);
            //        }
            //        break;
            //}

            //if (db.RewardMoneyNum > 0)
            //{
            //    DataManager.Instance.AddMoney(1, db.RewardMoneyNum);
            //}
            //if (db.RewardExpNum > 0)
            //{
            //    ZSRole.Instance.TryAddHeroExp(db.RewardExpNum);
            //}
            //if (db.AwardID > 0)
            //{
            //    ZTAward.Instance.OnReceiveAward(db.AwardID, true);
            //}
        }

        public void DoThreadNext()
        {
            if (CurThreadTask != null)
            {
                CurThreadTask.Start();
            }
        }

        public void DoBranchNext()
        {
            if (CurBranchTask != null)
            {
                CurBranchTask.Start();
            }
        }

        public void Step()
        {

        }


    }
}
