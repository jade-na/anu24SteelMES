using System;
using System.Collections.Generic;
using System.Linq;

namespace SteelMES
{
    public class UserSessionManager
    {
        private readonly List<UserSession> CurLogInUsers = new List<UserSession>();  // 현재 로그인된 사용자들
        private readonly object sessionLock = new object();  // 세션 처리 동기화용 락
                                                             // 사용자가 로그인되어 있는지 확인
        public bool IsUserLoggedIn(string username)
        {
            lock (sessionLock)
            {
                return CurLogInUsers.Any(user => user.UserId == username);  // 이미 로그인된 사용자가 있으면 true 반환
            }
        }
        // 사용자를 로그인된 사용자 리스트에 추가 (기존 세션이 있으면 클라이언트에 전달)
        public bool AddUserSession(string username, out bool forceExit)
        {
            lock (sessionLock)
            {
                forceExit = false;
                // 이미 로그인된 사용자가 있을 경우
                if (IsUserLoggedIn(username))
                {
                    forceExit = true;  // 중복 로그인 발견
                    return false; // 로그인 실패, 이미 로그인된 상태
                }
                // 새로운 세션 추가
                CurLogInUsers.Add(new UserSession
                {
                    UserId = username,
                    LoginTime = DateTime.UtcNow
                });
                return true; // 로그인 성공
            }
        }
        // 사용자를 강제 로그아웃 시도 (세션 제거)
        public bool ForceLogout(string username)
        {
            lock (sessionLock)
            {
                var session = CurLogInUsers.FirstOrDefault(user => user.UserId == username);
                if (session != null)
                {
                    CurLogInUsers.Remove(session);
                    return true; // 강제 로그아웃 성공
                }
                return false; // 해당 사용자가 로그인되어 있지 않음
            }
        }
        // 강제 로그아웃 후 중복 세션 종료 여부를 클라이언트에 전달
        public bool ForceLogoutAndReturnState(string username, out bool isUserLoggedOut)
        {
            lock (sessionLock)
            {
                var session = CurLogInUsers.FirstOrDefault(user => user.UserId == username);
                if (session != null)
                {
                    CurLogInUsers.Remove(session);
                    isUserLoggedOut = true; // 세션이 종료되었음
                    return true;
                }
                isUserLoggedOut = false; // 해당 사용자가 로그인되어 있지 않음
                return false;
            }
        }
    }
    public class UserSession
    {
        public string UserId { get; set; }
        public DateTime LoginTime { get; set; }
    }
}