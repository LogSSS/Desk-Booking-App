# ---- Stage 1: Build the Angular application ----
# Use an official Node.js image as the base.
# The 'alpine' version is a lightweight Linux distribution.
# Naming this stage 'builder'
FROM node:20-alpine AS builder

# Set the working directory inside the container
WORKDIR /usr/src/app

# Copy package.json and package-lock.json (or npm-shrinkwrap.json)
# This step is separated to leverage Docker's layer caching.
# If these files don't change, Docker won't re-run 'npm install'.
COPY package*.json ./

# Install all dependencies, including devDependencies needed for the build
RUN npm install

# Copy the rest of the application's source code
COPY . .

# Run the Angular build script from package.json
# This will create the production-ready files in the 'dist/' directory
RUN npm run build


# ---- Stage 2: Setup the production environment ----
# Use a fresh, lightweight Node.js Alpine image for the final container
FROM node:20-alpine

# Set the working directory
WORKDIR /usr/src/app

# Copy package.json and package-lock.json again
COPY package*.json ./

# Install ONLY the production dependencies (from 'dependencies' in package.json)
# The --omit=dev flag is crucial for a small and secure image.
RUN npm install --omit=dev

# Copy the built application from the 'builder' stage
# The path 'dist/client' comes from your 'serve:ssr:client' script
COPY --from=builder /usr/src/app/dist/client ./dist/client

# A good security practice is to run the container as a non-root user.
# The official Node image provides a 'node' user for this purpose.
USER node

# Expose the port the app runs on.
# Angular SSR's default port is often 4000. Check your server.mjs if it's different.
EXPOSE 4000

# The command to start the application.
# This is the 'serve:ssr:client' script from your package.json
CMD [ "node", "dist/client/server/server.mjs" ]