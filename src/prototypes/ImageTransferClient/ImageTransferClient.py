import grpc
from protos import image_pb2
from protos import image_pb2_grpc

def send_image(image_path, server_address="localhost:50051"):
    # gRPC 채널 설정
    channel = grpc.insecure_channel(server_address)
    stub = image_pb2_grpc.ImageServiceStub(channel)

    # 이미지를 바이너리로 읽기
    with open(image_path, "rb") as image_file:
        image_data = image_file.read()

    # gRPC 요청 생성
    request = image_pb2.ImageRequest(
        image_data=image_data,
        image_name=image_path.split("\\")[-1]  # 파일 이름만 추출
    )

    # 서버로 이미지 전송
    try:
        response = stub.SendImage(request)
        print(f"Response from server: {response.status}")
    except grpc.RpcError as e:
        print(f"gRPC error: {e.code()} - {e.details()}")

if __name__ == "__main__":
    send_image("C:\\Temp\\pic1.jpg")  # 이미지 경로
