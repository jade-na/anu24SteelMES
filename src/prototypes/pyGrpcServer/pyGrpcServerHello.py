import grpc
from concurrent import futures
import time
import hello_pb2
import hello_pb2_grpc

class GreeterServicer(hello_pb2_grpc.GreeterServicer):
    def SayHello(self, request, context):
        message = f"Hello, {request.name}!"
        return hello_pb2.HelloReply(message=message)
    def ReqRemoteCommand(self, request, context):
        print(f"received RCMD, RCMD= {request.command}, PARAM= {request.param}!")
        # TODO: 명령을 처리하는 부분 구현
        return hello_pb2.RcmdReply(ack="OK")

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    hello_pb2_grpc.add_GreeterServicer_to_server(GreeterServicer(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print("Server started on port 50051")
    
    try:
        while True:
            time.sleep(86400)
    except KeyboardInterrupt:
        server.stop(0)

if __name__ == '__main__':
    serve()