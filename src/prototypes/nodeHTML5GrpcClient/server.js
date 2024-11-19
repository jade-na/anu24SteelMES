const express = require('express');
const cors = require('cors');
const path = require('path');
const grpc = require('@grpc/grpc-js');
const protoLoader = require('@grpc/proto-loader');

const app = express();
const PROTO_PATH = './protos/hello.proto';

// Express 미들웨어 설정
app.use(cors());
app.use(express.json());
app.use(express.static('public'));

// Proto 파일 로드
const packageDefinition = protoLoader.loadSync(PROTO_PATH, {
    keepCase: true,
    longs: String,
    enums: String,
    defaults: true,
    oneofs: true
});

const hello_proto = grpc.loadPackageDefinition(packageDefinition).hello;
const client = new hello_proto.Greeter(
    'localhost:50051',
    grpc.credentials.createInsecure()
);

// API 엔드포인트
app.post('/sayHello', (req, res) => {
    const { name } = req.body;
    client.sayHello({ name: name }, (err, response) => {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        }
        res.json(response);
    });
});

// HTML 파일 서빙
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, 'public', 'index.html'));
});

const PORT = 3000;
app.listen(PORT, () => {
    console.log(`Server running on http://localhost:${PORT}`);
}); 