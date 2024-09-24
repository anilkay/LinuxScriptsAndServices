#!/bin/bash

# Directory to save the images

# Get current timestamp in YYYY-MM-DD_HH:MM:SS format
TIMESTAMP=$(date +"%Y-%m-%d_%H-%M-%S")

# Capture photo with fswebcam and save it with timestamp
fswebcam -r 640x480 --jpeg 85 -D 1 "$SAVE_DIR/photo_$TIMESTAMP.jpg"

# Print a message indicating the photo was captured
echo "Photo captured and saved as photo_$TIMESTAMP.jpg in $SAVE_DIR"

