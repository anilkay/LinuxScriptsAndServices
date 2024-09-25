# Wekan
- Docker Compose is easiest and most Portable Method.
- No Armv64 image for Wekan.
- Raspberry Pi with podman backend can't work because of SOC architecure. 

## Used Commands
### In Mac
docker compose up -f 
docker compose down
docker compose logs

### In RasperryPi
sudo apt-install podman-compose
podman-compose up
podman-compose down

## Notes
Meteor.js is fantastic.
