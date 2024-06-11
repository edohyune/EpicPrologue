using System;
using System.Collections.Generic;


namespace Ctrls
{
    public interface IWorkSet
    {
        /// <summary>
        /// 워크셋을 초기화합니다.
        /// </summary>
        void Initialize();

        /// <summary>
        /// 워크셋 데이터를 조회합니다.
        /// </summary>
        void Open();

        /// <summary>
        /// 워크셋 데이터를 저장합니다.
        /// </summary>
        void Save();

        /// <summary>
        /// 워크셋 데이터를 삭제합니다.
        /// </summary>
        void Delete();

        /// <summary>
        /// 워크셋 데이터의 변경 사항을 처리합니다.
        /// </summary>
        void OnDataChanged();

        /// <summary>
        /// 워크셋의 상태를 확인합니다.
        /// </summary>
        /// <returns>워크셋의 현재 상태</returns>
        WorkSetState GetState();
    }

    public enum WorkSetState
    {
        Initialized,
        Fetched,
        Saved,
        Deleted
    }

}