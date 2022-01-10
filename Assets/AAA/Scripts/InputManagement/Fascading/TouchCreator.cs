// source: https://answers.unity.com/questions/448771/simulate-touch-with-mouse.html

using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Sule.BoatStack.InputManagement.Fascading
{
    public class TouchCreator
    {
        private static readonly Dictionary<string, FieldInfo> Fields = new Dictionary<string, FieldInfo>();

        private readonly object _touch = new Touch();

        public float DeltaTime {
            get => ((Touch)_touch).deltaTime;
            set => Fields["m_TimeDelta"].SetValue(_touch, value);
        }

        public int TapCount {
            get => ((Touch)_touch).tapCount;
            set => Fields["m_TapCount"].SetValue(_touch, value);
        }

        public TouchPhase Phase {
            get => ((Touch)_touch).phase;
            set => Fields["m_Phase"].SetValue(_touch, value);
        }

        public Vector2 DeltaPosition {
            get => ((Touch)_touch).deltaPosition;
            set => Fields["m_PositionDelta"].SetValue(_touch, value);
        }

        public int FingerId {
            get => ((Touch)_touch).fingerId;
            set => Fields["m_FingerId"].SetValue(_touch, value);
        }

        public Vector2 Position {
            get => ((Touch)_touch).position;
            set => Fields["m_Position"].SetValue(_touch, value);
        }

        public Vector2 RawPosition {
            get => ((Touch)_touch).rawPosition;
            set => Fields["m_RawPosition"].SetValue(_touch, value);
        }

        static TouchCreator()
        {
            foreach(var f in typeof(Touch).GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                Fields.Add(f.Name, f);
            }
        }

        public Touch Create()
        {
            return (Touch)_touch;
        }
    }
}
