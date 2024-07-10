# Base stage
FROM node:14 AS base
WORKDIR /app

# Install dependencies
COPY package*.json ./
RUN npm install

# Copy the rest of the application
COPY . .

# Build stage
FROM base AS build
RUN npm run build

# Development stage
FROM base AS dev
EXPOSE 3000
CMD ["npm", "start"]

# Production stage
FROM nginx AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/build .
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
