import socket

user_command = ""  # 명령어를 저장할 문자열

def create_udp_socket():
    # UDP 소켓 생성
    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    sock.bind(('127.0.0.1', 10000))  # local port 10000
    # 소켓을 non-blocking 모드로 설정
    sock.setblocking(False)
    return sock

def check_terminal_command(sock):
    global user_command  # 전역 변수 사용
    try:
        # UDP로 데이터 수신 (버퍼 크기: 1024 바이트)
        data, addr = sock.recvfrom(1024)
        
        if len(data) <= 0:
            return
        
        # 받은 데이터를 문자열로 디코딩
        received = data.decode('utf-8')
        
        # 받은 데이터를 한 문자씩 처리
        for char in received:
            if char == '\n':  # 개행 문자를 만나면
                # 완성된 명령어 출력
                print(f"received command: {user_command}")
                user_command = ""  # 명령어 초기화
            else:
                # 개행이 아닌 문자는 명령어 문자열에 추가
                user_command += char
                
    except BlockingIOError:
        # 데이터가 없을 경우 발생하는 예외를 무시
        pass
    except Exception as e:
        print(f"error occurred: {e}")

def main_loop(sock):
    while True:
        # check_terminal_command를 계속 호출
        check_terminal_command(sock)

def main():
    try:
        # UDP 소켓 생성
        sock = create_udp_socket()
        print("UDP Server Start (local port: 10000)")
        
        # 메인 루프 실행
        main_loop(sock)
        
    except Exception as e:
        print(f"error occurred: {e}")
    finally:
        sock.close()

if __name__ == "__main__":
    main()
