using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace myUserSessionManager
{
	public class UserSession
	{
		public string UserId { get; set; }
		public DateTime LoginTime { get; set; }
	}

	public class UserSessionManager
	{
		private readonly List<UserSession> CurLogInUsers = new List<UserSession>();  // 현재 로그인된 사용자들
		private readonly object sessionLock = new object();  // 세션 처리 동기화용 락
		private readonly TimeSpan SessionTimeout = TimeSpan.FromMinutes(30);  // 세션 만료 시간 설정
		private readonly System.Threading.Timer sessionCleaner;  // 세션 만료 처리 타이머

		public UserSessionManager()
		{
			// 주기적으로 만료된 세션을 제거하는 타이머 설정 (30분마다)
			sessionCleaner = new System.Threading.Timer(RemoveExpiredSessions, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));

			// 프로그램 시작 시 만료된 세션을 한 번 정리
			RemoveExpiredSessions(null);
		}

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
				// 기본적으로 강제 로그아웃 여부는 false로 설정
				forceExit = false;

				// 이미 로그인된 사용자가 있을 경우
				if (IsUserLoggedIn(username))
				{
					// 기존 세션이 있으면, 강제 로그아웃 여부를 클라이언트에 전달
					forceExit = true;
					Console.WriteLine($"[INFO] {username}의 기존 세션이 중복 로그인으로 확인되었습니다.");
					return false; // 로그인 실패, 이미 로그인된 상태
				}

				// 새로운 세션 추가
				CurLogInUsers.Add(new UserSession
				{
					UserId = username,
					LoginTime = DateTime.UtcNow // UTC 시간을 사용하여 일관성 유지
				});
				Console.WriteLine($"[INFO] {username} 로그인 처리.");
				return true; // 로그인 성공
			}
		}

		// 사용자를 로그아웃 시도 (세션 제거)
		public bool RemoveUserSession(string username)
		{
			lock (sessionLock)
			{
				var session = CurLogInUsers.FirstOrDefault(user => user.UserId == username);
				if (session != null)
				{
					CurLogInUsers.Remove(session);
					Console.WriteLine($"[INFO] {username} 로그아웃 처리.");
					return true; // 로그아웃 성공
				}
				Console.WriteLine($"[WARN] {username}는 현재 로그인되어 있지 않습니다.");
				return false; // 로그인 상태가 아님
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
					Console.WriteLine($"[INFO] {username} 강제 로그아웃 처리.");
					return true; // 강제 로그아웃 성공
				}
				Console.WriteLine($"[WARN] {username}는 로그인되어 있지 않아서 강제 로그아웃 처리할 수 없습니다.");
				return false; // 해당 사용자가 로그인되어 있지 않음
			}
		}

		// 만료된 세션을 정리
		private void RemoveExpiredSessions(object state)
		{
			lock (sessionLock)
			{
				DateTime now = DateTime.UtcNow; // UTC 시간을 사용하여 일관성 유지
				var expiredSessions = CurLogInUsers.Where(user => now - user.LoginTime > SessionTimeout).ToList();

				if (expiredSessions.Count > 0)
				{
					foreach (var expiredSession in expiredSessions)
					{
						CurLogInUsers.Remove(expiredSession);
						Console.WriteLine($"[INFO] {expiredSession.UserId}의 세션이 만료되어 삭제되었습니다.");
					}
				}
				else
				{
					Console.WriteLine("[INFO] 만료된 세션이 없습니다.");
				}
			}
		}
	}
}
