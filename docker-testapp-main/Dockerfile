FROM node

ENV MONGO_DB_USERNAME=admin \
    MONDO_DB_PWD=qwerty

WORKDIR /app

COPY . .

RUN npm install

CMD ["node", "server.js"]
