FROM node:14-alpine AS build
WORKDIR /app
COPY src/PetShopUI .
RUN npm ci && npm run build

FROM nginx:1.22-alpine
COPY --from=build /app/dist/PetShopUI /usr/share/nginx/html